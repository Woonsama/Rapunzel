using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPotion : ObjectBase
{
    CameraManager cameraManager;

    protected override IEnumerator OnAwakeCoroutine()
    {
        cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        Invoke("Bomb", 1.0f);
        return base.OnAwakeCoroutine();
    }
    
    private void Bomb()
    {
        cameraManager.Do_Shake(0.5f,0.5f);

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemy.Length; i++)
            enemy[i].GetComponent<cEnemy>().HitbyPotion(100, 9999);

        Destroy(this.gameObject);
    }
}
