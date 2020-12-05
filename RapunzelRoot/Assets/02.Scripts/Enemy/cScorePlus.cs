using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cScorePlus : MonoBehaviour
{
    [SerializeField]
    [Header("죽으면주는점수량")]
    private int m_nScore;

    [SerializeField]
    [Header("죽으면주는재화량")]
    private int m_nMoney;

    public void SetScoreNMoney(int _score, int _money)
    {
        m_nScore = _score;
        m_nMoney = _money;
    }

    public void AddScore()
    {
        //죽으면 점수 추가
    }
    public void AddMoney()
    {
        //죽으면 돈추가
    }

}
