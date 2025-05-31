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

    public Canvas whereWeAre;
    public Canvas whereDoWeGo;

    TypingGameModel gameModel;

    public int errorCount = 0;

    void Start()
    {
        gameModel = new TypingGameModel(gameModelText, textHintText, this, whereWeAre, whereDoWeGo);
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

    Canvas whereWeAreC;
    Canvas whereDoWeGoC;

    public TypingGameModel(TextMeshProUGUI gameText, TextMeshProUGUI hintText, TypingGameController controller, Canvas whereWeAre, Canvas whereDoWeGo)
    {
        this.controller = controller;
        this.gameText = gameText;
        this.hintText = hintText;
        this.whereDoWeGoC=whereDoWeGo;
        this.whereWeAreC=whereWeAre;
        hintRows = hintText.text.ToString().Split("\n").ToList<string>();
        UpdateGameView();
    }

    public void Process(char c)
    {
        int currentRow = gameRows.Count - 1;

        if (c == '\b') // Backspace
            return;
        else if (c == '\n' || c == '\r') // Enter
            return;
        else
        {
            gameRows[currentRow] += c;
            if (c == getCurrentHintChar())
            {
                int pom = currentHintRow;
                incrementCurrentHintChar();
                if (pom != currentHintRow)
                {
                    gameRows.Add("");
                }

            }
            else
            {
                //dodaj u hintText na tom mjestu
                hintRows[currentHintRow] = hintRows[currentHintRow].Substring(0, currentHintColumn) + c + hintRows[currentHintRow].Substring(currentHintColumn);
                incrementCurrentHintChar();

                //increment error
                errorCount++;
                controller.errorCount = this.errorCount;
            }
        }

        UpdateGameView();
        UpdateHintView();
    }

    void incrementCurrentHintChar()
    {
        currentHintColumn++;
        if (currentHintColumn >= hintRows[currentHintRow].Length)
        {
            currentHintColumn = 0;
            currentHintRow++;
        }
        if (currentHintRow >= hintRows.Count) GameFinished();
    }

    char getCurrentHintChar()
    {
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
        Debug.Log("kliknut");
        whereDoWeGoC.gameObject.SetActive(true);
        whereWeAreC.gameObject.SetActive(false);

    }

}
