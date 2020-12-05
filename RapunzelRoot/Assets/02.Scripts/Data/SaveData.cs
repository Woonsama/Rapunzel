using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{

    public int iGold { get; private set; }
    public int iScore { get; private set; }

    public GameData()
    {
        iGold = 0;
        iScore = 0;
    }

    public void Do_Add_Or_Minus_Gold(int gold)
    {
        iGold += gold;
        SaveData();
    }

    public void Do_Add_Score(int score)
    {
        iScore += score;
        SaveData();
    }

    public void ResetScore()
    {
        iScore = 0;
        SaveData();
    }

    public void ResetGold()
    {
        iGold = 0;
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Gold", iGold);
        PlayerPrefs.SetInt("Score", iGold);
    }

    public void LoadData()
    {
        iGold = PlayerPrefs.GetInt("Gold");
        iScore = PlayerPrefs.GetInt("Score");
    }

}
