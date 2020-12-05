using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :ObjectBase
{
    public int Health { get; set; } = 3;
    public bool isDie { get; set; } = false;

    public void Hit()
    {
        Health--;

        if (Health == 0) isDie = true;
    }
}
