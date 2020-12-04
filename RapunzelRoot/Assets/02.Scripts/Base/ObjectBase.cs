using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }

    private void OnEnable()
    {
        OnEnabled();
    }

    private void OnAwake()
    {
        StartCoroutine(OnAwakeCoroutine());
    }

    private void OnEnabled()
    {
        StartCoroutine(OnEnableCoroutine());
    }

    protected virtual IEnumerator OnAwakeCoroutine()
    {
        yield break;
    }

    protected virtual IEnumerator OnEnableCoroutine()
    {
        yield break;
    }
}
