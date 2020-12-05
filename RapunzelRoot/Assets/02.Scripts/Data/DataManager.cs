using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBase<DataManager>
{
    public GameData gameData;

    public int currentWaveIndex { get; set; } = 0;

    public int[] PotionLevel = new int[4];

    public int iHaveGoldPotionCount { get; set; } = 0;
    /*
        Red = 0,
        Blue,
        Green,
        Yellow,
     */
    private void Awake()
    {
        DontDestroyOnLoad(this);
        gameData = new GameData();
        gameData.LoadData();
    }
}
