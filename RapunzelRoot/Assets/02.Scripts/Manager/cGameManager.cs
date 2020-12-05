using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGameManager : MonoBehaviour
{
    static public cGameManager instance;
    public int g_nWave { get; set; }
    [SerializeField]
    GameObject EnemySpawner;

    [SerializeField]
    GameObject InGameUI;
    [SerializeField]
    GameObject ShopUI;

    public bool g_bIsGameStart;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        g_nWave = 0;
        WaveStart();
    }

    public void WaveStart()
    {
        InGameUI.SetActive(true);
        ShopUI.SetActive(false);
        g_nWave++;
        cEnemyDeadCheck.instance.m_nEnemyCount = 0;//라운드시작시 적수 초기화
        GameObject spawner = Instantiate(EnemySpawner, Vector3.zero, Quaternion.identity);

        //스테이지별 스포너세팅(스폰딜레이,스폰주기, 한번에몇마리, 총스폰되는몬스터의수
        spawner.GetComponent<cEnemySpawner>().Init(2, 1, 1, 20);

        g_bIsGameStart = true;
    }
    public void WaveEnd()
    {
        InGameUI.SetActive(false);
        ShopUI.SetActive(true);
        g_bIsGameStart = false;
    }

}
