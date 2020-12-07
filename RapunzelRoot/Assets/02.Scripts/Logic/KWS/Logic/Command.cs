using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command : ObjectBase
{
    //Const
    const int c_LiquorCount = 4;
    const int c_InitialLength = 4;

    //Public
    public bool isSuccessed { get; set; }

    [Header("Pattern")]
    public string[] str_LiquorCombo = new string[4];

    [Header("Pattern Current")]
    public string str_CurrentCommand;

    [Header("Liquor Answer Index")]
    public int liquorIndex;

    [Header("Gold Potion")]
    public GameObject goldPotion;
    public Vector3 goldPotionGeneratePos;

    [Header("Button")]
    public Button up;
    public Button down;
    public Button left;
    public Button right;
    public Button reset;
    public Button btn_GoldPotion;



    public bool isCorrectCommand { get; set; }

    protected override IEnumerator OnAwakeCoroutine()
    {
        up.onClick?.AddListener(OnClick_UpArrow);
        down.onClick?.AddListener(OnClick_DownArrow);
        left.onClick?.AddListener(OnClick_LeftArrow);
        right.onClick?.AddListener(OnClick_RightArrow);
        reset.onClick?.AddListener(OnClick_Reset);


        InitPattern();
        return base.OnAwakeCoroutine();
    }

    private void Update()
    {
        InputCheck();
    }

    public void ReleaseCommand()
    {
        str_CurrentCommand = string.Empty;
    }

    public void AddPattern(int index)
    {
        str_LiquorCombo[index] += GetRandomCommand();      
    }

    #region private

    private void InitPattern()
    {
        for(int i = 0; i < c_LiquorCount; i++)
        {
            for(int j = 0; j < c_InitialLength; j++)
            {
                str_LiquorCombo[i] += GetRandomCommand();
            }
        }
    }

    private string GetRandomCommand()
    {
        string[] str_temp = { "Q", "W", "E", "R" };

        return str_temp[Random.Range(0, 4)];
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Typing("Q");
        if (Input.GetKeyDown(KeyCode.RightArrow)) Typing("W");
        if (Input.GetKeyDown(KeyCode.UpArrow)) Typing("E");
        if (Input.GetKeyDown(KeyCode.DownArrow)) Typing("R");
        if (Input.GetKeyDown(KeyCode.LeftShift)) CreateGoldPotion();
        if (Input.GetKeyDown(KeyCode.Z)) ReleaseCommand();

    }

    private void CreateGoldPotion()
    {
        if(DataManager.Instance.iHaveGoldPotionCount > 0)
        {
            Instantiate(goldPotion, goldPotionGeneratePos, Quaternion.identity);
            DataManager.Instance.iHaveGoldPotionCount--;
        }
    }

    private void Typing(string str_Command)
    {
        str_CurrentCommand += str_Command;
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

    #region Event

    public void OnClick_LeftArrow()
    {
        Typing("Q");
    }

    public void OnClick_RightArrow()
    {
        Typing("W");
    }

    public void OnClick_UpArrow()
    {
        Typing("E");
    }

    public void OnClick_DownArrow()
    {
        Typing("R");
    }

    public void OnClick_Reset()
    {
        ReleaseCommand();
    }

    public void OnClick_GoldPotion()
    {
        CreateGoldPotion();
    }

    #endregion Event
}
