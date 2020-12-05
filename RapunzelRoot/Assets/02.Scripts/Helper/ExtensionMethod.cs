using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionMethod : MonoBehaviour
{
    public static bool isCanShake = true;

    public static IEnumerator Shake(Transform targetTransform, float magnitude, float duration)
    {
        if(isCanShake)
        {
            isCanShake = false;
            Vector3 originalPos = targetTransform.position;
            float time = 0;

            while (time <= duration)
            {
                time += Time.deltaTime;
                float x = Random.Range(-1.0f, 1.0f) * magnitude;
                float y = Random.Range(-1.0f, 1.0f) * magnitude;

                targetTransform.position = Vector3.MoveTowards(targetTransform.position, originalPos + new Vector3(x, y, 0), 1);
                yield return null;
            }

            targetTransform.position = originalPos;
            isCanShake = true;
        }
    }
}
