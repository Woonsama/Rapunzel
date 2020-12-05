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
    }

    public void ReleaseCommand()
    {
        str_CurrentCommand = string.Empty;
    }

    #region private


    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Typing("Q");
        if (Input.GetKeyDown(KeyCode.W)) Typing("W");
        if (Input.GetKeyDown(KeyCode.E)) Typing("E");
        if (Input.GetKeyDown(KeyCode.R)) Typing("R");

    }

    private void Typing(string str_Command)
    {
        str_CurrentCommand += str_Command;
        Debug.Log(str_CurrentCommand);
        PatternCorrectCheck();
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
                SoundManager.Instance.PlayOneShot("Sound/InGame/CommandCorrect");
                Debug.Log("Command Correct");
                break;
            }
            else
            {
                if(str_LiquorCombo[i].Length < str_CurrentCommand.Length)
                {
                    ReleaseCommand(); 
                    SoundManager.Instance.PlayOneShot("Sound/InGame/CommandFail");
                }
                else
                {
                    SoundManager.Instance.PlayOneShot("Sound/InGame/CommandTouch");
                }
            }

        }
    }

    #endregion private
}
