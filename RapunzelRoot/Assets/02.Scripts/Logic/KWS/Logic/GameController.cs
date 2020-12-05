using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : ObjectBase
{
    [Header("Command")]
    public Command command;

    [Header("Shooter")]
    public Shooter shooter;

    [Header("Player")]
    public Player player;

    [Header("Liquor Generator")]
    public LiquorGenerator liquorGenerator;
    public Transform liquorGeneratePos;
    public GameObject liquorParent;

    public bool isWaveClear { get; set; }

    [Header("EnemySpawner")]
    public GameObject EnemySpawner;

    [Header("ShopUI")]
   public  GameObject ShopUI;

    [Header("Wave Count")]
    public int waveCount;

    [Header("Enemy Spawn Data")]
    public EnemySpawnData[] enemySpawnData;


    protected override IEnumerator OnAwakeCoroutine()
    {
        DataManager.Instance.gameData.ResetScore();
        DataManager.Instance.gameData.ResetGold();

        for (int i = 0; i < waveCount; i++)
		{
            yield return StartCoroutine(Wave_Coroutine());
        }

        yield return StartCoroutine(GameClear_Coroutine());
    }

    private IEnumerator Wave_Coroutine()
	{
        while (!isWaveClear)
        {
            Init();
            yield return StartCoroutine(Command_Coroutine());
            yield return StartCoroutine(Shooter_Coroutine());
            yield return StartCoroutine(Fire_Coroutine());
            yield return null;
        }

        yield return StartCoroutine(Shop_Coroutine());
        DataManager.Instance.currentWaveIndex++;
    }

    private IEnumerator Shop_Coroutine()
	{
        OpenShop();

        yield break;
	}

    private void OpenShop()
    {
        Time.timeScale = 0;
        ShopUI.SetActive(true);
    }

    private void CloseShop()
    {
        Time.timeScale = 1;
    }

    private IEnumerator GameClear_Coroutine()
	{
        //Game Clear
        yield break;
	}

    private void Init()
    {
        shooter.gameObject.SetActive(false);
        command.ReleaseCommand();
        isWaveClear = false;

        EnemySpawner.GetComponent<cEnemySpawner>().Init(
            enemySpawnData[DataManager.Instance.currentWaveIndex].spawnDelay,
            enemySpawnData[DataManager.Instance.currentWaveIndex].spawnTime,
            enemySpawnData[DataManager.Instance.currentWaveIndex].howMany,
            enemySpawnData[DataManager.Instance.currentWaveIndex].maxSpawnCount);


       // ShopUI.SetActive(false);
    }

    private IEnumerator Command_Coroutine()
    {
        while(!command.isCorrectCommand)
        {
            yield return null;
        }
        command.isCorrectCommand = false;
    }

    private IEnumerator Shooter_Coroutine()
    {
        shooter.gameObject.SetActive(true);

        bool isFire = false;

        while(!isFire)
        {
            shooter.Do_Move();

            if (Input.GetKeyDown(KeyCode.Space))
                isFire = true;

            yield return null;
        }
        yield break;
    }

    private IEnumerator Fire_Coroutine()
    {
        liquorGenerator.GenerateLiquor(command.liquorIndex,liquorGeneratePos, liquorParent.transform);        
        yield break;
    }

    private IEnumerator ClearCheck_Coroutine()
    {
        while(!player.isDie)
        {            
            yield return null;
        }
    }
}

[System.Serializable]
public class EnemySpawnData
{
    public float spawnDelay;
    public float spawnTime;
    public int howMany;
    public int maxSpawnCount;

}
