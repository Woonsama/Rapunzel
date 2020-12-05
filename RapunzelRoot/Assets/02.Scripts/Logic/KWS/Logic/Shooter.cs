using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : ObjectBase
{
    [Header("Rotate Offset")]
    public float rotateOffset = 25f;

    [Header("RotateSpeed")]
    public float rotateSpeed = 50.0f;

    [Header("Rotate Target")]
    public GameObject rotateTarget;

    float time;

    public void Do_Move()
    {
        time = Time.time;
        rotateTarget.transform.rotation = Quaternion.Euler(0, 0, Mathf.PingPong(time * rotateSpeed, rotateOffset * 2) - rotateOffset);
    }


    public void Do_Stop()
    {
        rotateTarget.transform.rotation = Quaternion.Euler(0, 0, 0);
        time = 0;
    }
}
