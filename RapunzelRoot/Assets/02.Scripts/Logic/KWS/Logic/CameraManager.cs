using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void Do_Shake(float magnitude, float duration)
    {
        StartCoroutine(ExtensionMethod.Shake(Camera.main.transform, magnitude, duration));
    }
}
