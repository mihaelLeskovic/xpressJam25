using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class TypingGameController : MonoBehaviour
{
    public TextMeshProUGUI gameModelText;
    public TextMeshProUGUI textHintText;
    public int errorCount = 0;

    TypingGameModel gameModel;

    void Start()
    {
        gameModel = new TypingGameModel(gameModelText, textHintText, this);
    }

    void Update()
    {
        TakeInputs();
    }

    void TakeInputs()
    {
        foreach (char c in Input.inputString)
        {
            gameModel.Process(c);
        }
    }
}

public class TypingGameModel
{
    List<string> gameRows = new List<string> { "" };
    List<string> hintRows;
    int currentHintRow = 0;
    int currentHintColumn = 0;
    TextMeshProUGUI gameText;
    TextMeshProUGUI hintText;
    int errorCount = 0;
    TypingGameController controller;

    public TypingGameModel(TextMeshProUGUI gameText, TextMeshProUGUI hintText, TypingGameController controller)
    {
        this.controller = controller;
        this.gameText = gameText;
        this.hintText = hintText;
        hintRows = hintText.text.ToString().Split("\n").ToList<string>();
        UpdateGameView();
    }

    public void Process(char c)
    {
        int currentRow = gameRows.Count - 1;

        if (c == '\b' || c == '\n' || c == '\r' || c == ' ')
            return;

        // Step 1: Pre-skip and insert all spaces from hint
        while (getCurrentHintChar() == ' ')
        {
            gameRows[currentRow] += ' ';
            incrementCurrentHintChar();
            if (currentHintRow != currentRow) // row advanced
            {
                currentRow = gameRows.Count - 1;
            }
        }

        // Step 2: Add typed char
        gameRows[currentRow] += c;

        if (c == getCurrentHintChar())
        {
            int oldRow = currentHintRow;
            incrementCurrentHintChar();

            // Step 3: Post-skip spaces too (including newlines)
            while (getCurrentHintChar() == ' ')
            {
                if (currentHintRow != oldRow)
                {
                    gameRows.Add("");
                    currentRow++;
                }
                gameRows[currentRow] += ' ';
                incrementCurrentHintChar();
            }

            if (currentHintRow != oldRow)
            {
                gameRows.Add("");
            }
        }
        else
        {
            // Mistake: insert typed char into hint and count error
            hintRows[currentHintRow] = hintRows[currentHintRow].Substring(0, currentHintColumn) + c + hintRows[currentHintRow].Substring(currentHintColumn);
            incrementCurrentHintChar();
            errorCount++;
            controller.errorCount = this.errorCount;
        }

        UpdateGameView();
        UpdateHintView();
    }



    void SkipHintSpaces()
    {
        while (currentHintRow < hintRows.Count && currentHintColumn < hintRows[currentHintRow].Length &&
               hintRows[currentHintRow][currentHintColumn] == ' ')
        {
            incrementCurrentHintChar();
        }
    }

    void incrementCurrentHintChar()
    {
        currentHintColumn++;
        if (currentHintRow < hintRows.Count && currentHintColumn >= hintRows[currentHintRow].Length)
        {
            currentHintColumn = 0;
            currentHintRow++;
        }
        if (currentHintRow >= hintRows.Count)
        {
            GameFinished();
        }
    }

    char getCurrentHintChar()
    {
        if (currentHintRow >= hintRows.Count || currentHintColumn >= hintRows[currentHintRow].Length)
            return '\0';
        return hintRows[currentHintRow][currentHintColumn];
    }


    void UpdateGameView()
    {
        gameText.text = string.Join("\n", gameRows);
    }

    void UpdateHintView()
    {
        hintText.text = string.Join("\n", hintRows);
    }

    public string GetRow(int index)
    {
        return (index >= 0 && index < gameRows.Count) ? gameRows[index] : "";
    }

    void GameFinished()
    {
        ActivityManager.Instance.PopFromInactiveStack();
        GameObject.Destroy(controller.gameObject);
    }

}
