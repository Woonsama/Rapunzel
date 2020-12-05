using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : ObjectBase
{
    public GameObject[] child { get; set; }
    protected override IEnumerator OnAwakeCoroutine()
    {
        child = new GameObject[transform.childCount];
        return base.OnAwakeCoroutine();
    }

    public void GetChildGameObject()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
        }
    }

}
