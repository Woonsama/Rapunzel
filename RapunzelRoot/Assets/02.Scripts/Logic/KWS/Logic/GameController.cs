using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Button Fire")]
    public Button button_Fire;


    protected override IEnumerator OnAwakeCoroutine()
    {
        button_Fire.onClick?.AddListener(OnClick_Fire);

        DataManager.Instance.gameData.ResetScore();
        DataManager.Instance.gameData.ResetGold();
        DataManager.Instance.currentWaveIndex = 0;

        for (int i = 0; i < waveCount; i++)
		{
            yield return StartCoroutine(Wave_Coroutine());
        }

        yield return StartCoroutine(GameClear_Coroutine());
    }

    private IEnumerator Wave_Coroutine()
	{
        Init();

        while (!isWaveClear)
        {
            StartCoroutine(GameCoroutine());
            yield return null;
        }        
        DataManager.Instance.currentWaveIndex++;

        yield return StartCoroutine(WaveClear_Coroutine());
        yield return StartCoroutine(Shop_Coroutine());
        RemoveEnemyAll();
    }

    private IEnumerator GameCoroutine()
	{

        yield return StartCoroutine(Command_Coroutine());
        yield return StartCoroutine(Shooter_Coroutine());
        yield return StartCoroutine(Fire_Coroutine());
    }

    private void RemoveEnemyAll()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemy.Length; i++)
        Destroy(enemy[i]);
    }

    private IEnumerator WaveClear_Coroutine()
    {
        SoundManager.Instance.PlayBGM("Sound/InGame/WaveClear");

        GameObject.Find("Canvas_WaveClear").GetComponent<Animation>().Play("WaveClear");
        yield return new WaitForSeconds(1.3f);
    }

    private IEnumerator Shop_Coroutine()
	{
        yield return StartCoroutine(OpenShop());

        yield break;
	}

    private IEnumerator OpenShop()
    {
        ShopUI.SetActive(true);
        SoundManager.Instance.PlayBGM("Sound/Shop/ShopBGM");

        cShop shop = ShopUI.GetComponent<cShop>();
        shop.isClose = false;
        while (!shop.isClose)
        {
            yield return null;
        }

        SoundManager.Instance.PlayBGM("Sound/InGame/InGameBGM");

    }

    private IEnumerator GameClear_Coroutine()
	{
        //Game Clear
        yield break;
	}

    private void ShooterInit()
    {
        shooter.gameObject.SetActive(false);
        command.ReleaseCommand();
    }
	private void Init()
	{

        isWaveClear = false;
        EnemySpawner.GetComponent<cEnemySpawner>().Init(
            enemySpawnData[DataManager.Instance.currentWaveIndex].spawnDelay,
            enemySpawnData[DataManager.Instance.currentWaveIndex].spawnTime,
            enemySpawnData[DataManager.Instance.currentWaveIndex].howMany,
            enemySpawnData[DataManager.Instance.currentWaveIndex].maxSpawnCount);
        ShopUI.SetActive(false);
    }

	private IEnumerator Command_Coroutine()
    {
        while(!command.isCorrectCommand)
        {
            //if (isWaveClear == true)
            //    break;
            yield return null;
        }
        command.isCorrectCommand = false;
    }

    bool isFire = false;
    private IEnumerator Shooter_Coroutine()
    {
        shooter.gameObject.SetActive(true);

        isFire = false;

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
        player.gameObject.transform.Find("goel").GetComponent<Animator>().SetTrigger("shot");
        ShooterInit();
        yield break;
    }

    private IEnumerator ClearCheck_Coroutine()
    {
        while(!player.isDie)
        {            
            yield return null;
        }
    }

    private void OnClick_Fire()
    {
        if(!isFire)
        {
            isFire = true;
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
