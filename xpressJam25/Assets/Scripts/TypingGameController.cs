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

    TypingGameModel gameModel;


    void Start()
    {
        gameModel = new TypingGameModel(gameModelText, textHintText);
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

    public TypingGameModel(TextMeshProUGUI gameText, TextMeshProUGUI hintText)
    {
        this.gameText = gameText;
        this.hintText = hintText;
        hintRows = hintText.text.ToString().Split("\n").ToList<string>();
        UpdateView();
    }

    public void Process(char c)
    {
        int currentRow = gameRows.Count - 1;

        if (c == '\b') // Backspace
        {
            return;
            // if (rows[currentRow].Length > 0)
            //     rows[currentRow] = rows[currentRow].Substring(0, rows[currentRow].Length - 1);
            // else if (currentRow > 0)
            //     rows.RemoveAt(currentRow); // remove empty row
        }
        else if (c == '\n' || c == '\r') // Enter
        {
            return;
            // rows.Add("");
        }
        else
        {
            gameRows[currentRow] += c;
        }

        UpdateView();
    }

    bool offerCharToHint(char c)
    {
        if (c == getCurrentHintChar())
        {
            //dodaj u gameText
            //incrementCurrentHintChar
            return true;
        }
        else
        {

            //dodaj u gameText
            //dodaj u hintText na tom mjestu
            //increment error
            return false;
        }
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

    void UpdateView()
    {
        gameText.text = string.Join("\n", gameRows);
    }

    public string GetRow(int index)
    {
        return (index >= 0 && index < gameRows.Count) ? gameRows[index] : "";
    }

    void GameFinished()
    {

    }

}
