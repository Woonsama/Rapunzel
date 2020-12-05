﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInGameUi : MonoBehaviour
{
    [SerializeField]
    private Text m_txtScoreText;
    [SerializeField]
    private Text m_txtMopneyText;
    [SerializeField]
    private GameObject[] m_goHps;

    [SerializeField]
    private Sprite m_imgHpempty;

    [SerializeField]
    private Sprite m_imgHpFull;

    [SerializeField]
    private Text tests;

    private void Awake()
	{
        Init();
	}
    public void Init()
    {
        for (int i = 0; i < m_goHps.Length; i++)
        {
            m_goHps[i].GetComponent<Image>().sprite = m_imgHpFull;
        }
    }

    public void SetScoreText(int _value)
    {
        m_txtScoreText.text = _value.ToString();
    }
    public void SetMoneyText(int _value)
    {
        m_txtMopneyText.text = _value.ToString();
    }
    public void HpHit(int _index)
    {
        m_goHps[_index].GetComponent<Image>().sprite = m_imgHpempty;
    }
	private void Update()
	{
        tests.text = cEnemyDeadCheck.instance.m_nEnemyCount.ToString();
    }

}
