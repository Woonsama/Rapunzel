using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : ObjectBase
{
    public GameObject[] child { get; set; }
    protected override IEnumerator OnAwakeCoroutine()
    {
        child = new GameObject[transform.childCount];
        GetChildGameObject();
        return base.OnAwakeCoroutine();
    }

    private void GetChildGameObject()
    {
        if(transform.childCount != 0)
        child = GetComponentsInChildren<GameObject>();
    }

}
