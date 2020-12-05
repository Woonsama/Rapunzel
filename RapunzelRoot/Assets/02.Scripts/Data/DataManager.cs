using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBase<DataManager>
{
    public GameData gameData;

    public int currentWaveIndex { get; set; } = 0;

    public int[] PotionLevel= {0,0,0,0};
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
    }
}
