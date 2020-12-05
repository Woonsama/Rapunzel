using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBase<DataManager>
{
    public GameData gameData;

    public int currentWaveIndex { get; set; } = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        gameData = new GameData();
    }
}
