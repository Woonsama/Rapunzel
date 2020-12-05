using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemySpawner : MonoBehaviour
{
    [SerializeField]
    [Header("적소환딜레이")]
    private float m_fSecValue;
    [SerializeField]
    [Header("적스폰주기")]
    private float m_fSpawnTime;
    [SerializeField]
    [Header("한번에몇마리스폰")]
    private int m_nHowMany;
    [SerializeField]
    [Header("이번스테이지 몇마리 스폰")]
    private int m_nLimitSpawnNumber;
    [SerializeField]
    [Header("적프리팹들")]
    private GameObject[] EnemyPrefabs;
    [SerializeField]
    [Header("적스폰되는높이")]
    private float m_fSpawnYPos;
    [SerializeField]
    [Header("스폰x위치(0최소1최대)")]
    private float[] m_fSpawnMinnMax = new float[2];

    private float m_fCurrentSpawnTime;

    [SerializeField]
    [Header("deadchecker")]
    public cEnemyDeadCheck cEDC;

    bool isGameStart;

	// Update is called once per frame
	void Update()
    {
        if (isGameStart == false) return;

        if (m_fSecValue > 0)
        {
            m_fSecValue -= Time.deltaTime;
        }
        else
        {
            m_fCurrentSpawnTime -= Time.deltaTime;
            if(m_fCurrentSpawnTime <= 0)
            {
                m_fCurrentSpawnTime = m_fSpawnTime;
                StartCoroutine(SpawnEnemy());
            }
        }
    }
    //몇초후부터스폰시작,스폰주기,1번에몇마리,몇마리까지소환
    public void Init(float spawndelayTime, float spawntime, int _howmany, int _limitspawn)
    {
        isGameStart = true;
        m_fSecValue = spawndelayTime;
        m_fSpawnTime = spawntime;
        m_nHowMany = _howmany;
        m_nLimitSpawnNumber = _limitspawn;
        m_fCurrentSpawnTime = 0;
        cEDC.m_nEnemyCount += _limitspawn;//적수체크 증가
    }//스폰시 몬스터체력설정하기

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < m_nHowMany; i++)
        {
            int SpawnType =Random.Range(0, EnemyPrefabs.Length);

            GameObject Enemy = Instantiate(EnemyPrefabs[SpawnType],
                new Vector3(Random.Range(m_fSpawnMinnMax[0], m_fSpawnMinnMax[1]), m_fSpawnYPos, 0), Quaternion.identity);
            int _EnemyUpgrade = 0;
            int _MaxUpgrade = 0;
            if (DataManager.Instance.currentWaveIndex >= 4)
            {
                _MaxUpgrade = 1;
            }
            if (DataManager.Instance.currentWaveIndex >= 10)
            {
                _MaxUpgrade = 2;
            }
            _EnemyUpgrade = Random.Range(0, _MaxUpgrade);
            Enemy.GetComponent<cEnemy>().Init(1+_EnemyUpgrade, _EnemyUpgrade);

            m_nLimitSpawnNumber--;
            if (m_nLimitSpawnNumber <= 0)//이너미스포너 끝
            {
                isGameStart = false;
                StopCoroutine(SpawnEnemy());
                break;
            }
            yield return new WaitForSeconds(Random.Range(0.0f,0.6f));
        }
        yield return null;
        StopCoroutine(SpawnEnemy());
    }
}
