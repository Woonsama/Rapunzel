using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemyDeadCheck : MonoBehaviour
{
    public int m_nEnemyCount;
    // Start is called before the first frame update
	public void AddEnemyCount(int _value)
    {
        m_nEnemyCount = _value;
    }

    public void MinusEnemyCount()
    {
        m_nEnemyCount --;
    }
    public bool IsGameOver()
    {
        if (m_nEnemyCount <= 0)
            return true;
        else
            return false;
    }
}
