using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquorGenerator : MonoBehaviour
{
    const int c_LiquorCount = 4;

    [Header("Liquor")]
    public GameObject[] liquor = new GameObject[c_LiquorCount];

    /// <summary>
    /// 물약을 생성함.
    /// </summary>
    /// <param name="liquorIndex">물약 종류 번호</param>
    /// <param name="parent">물약 부모</param>
    public void GenerateLiquor(int liquorIndex,Transform generatePos, Transform parent)
    {
        Instantiate(liquor[liquorIndex],generatePos.position, Quaternion.identity, parent);
    }
}
