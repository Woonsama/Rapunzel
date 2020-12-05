using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPotion : ObjectBase
{
    protected override IEnumerator OnAwakeCoroutine()
    {
        Invoke("Bomb", 1.5f);
        return base.OnAwakeCoroutine();
    }
    
    private void Bomb()
    {

    }
}
