using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : ObjectBase
{
    //Const
    const int c_LiquorCount = 4;

    //Public
    public bool isSuccessed { get; set; }

    [Header("Pattern")]
    public string[] str_LiquorCombo = new string[4];

    [Header("Pattern Current")]
    public string str_CurrentCommand;

    [Header("Liquor Answer Index")]
    public int liquorIndex;

    public bool isCorrectCommand { get; set; }

    private void Update()
    {
        InputCheck();
        PatternCorrectCheck();
    }

    #region private

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q)) str_CurrentCommand += "Q";
        if (Input.GetKeyDown(KeyCode.W)) str_CurrentCommand += "W";
        if (Input.GetKeyDown(KeyCode.E)) str_CurrentCommand += "E";
        if (Input.GetKeyDown(KeyCode.R)) str_CurrentCommand += "R";

        Debug.Log(str_CurrentCommand);
    }

    private void PatternCorrectCheck()
    {
        for(int i = 0; i < str_LiquorCombo.Length; i++)
        {
            if(str_LiquorCombo[i] == str_CurrentCommand)
            {
                liquorIndex = i;
                ReleaseCommand();
                isCorrectCommand = true;
                break;
            }

            ReleaseCommand(); 
        }
    }

    private void ReleaseCommand()
    {
        str_CurrentCommand = string.Empty;
    }

    #endregion private
}
