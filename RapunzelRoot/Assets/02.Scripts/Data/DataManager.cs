using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBase<DataManager>
{
    GameData gameData;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        gameData = new GameData();
    }
}
