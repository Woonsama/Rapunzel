using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player :ObjectBase
{
    public int Health { get; set; } = 3;
    public bool isDie { get; set; } = false;
    public cInGameUi inGameui;
    public void Hit()
    {
        if(Health > 0) Health--;

        if (Health == 0)
        {
            isDie = true;
            Health = 0;
            SceneManager.LoadScene("Title");
        }
        inGameui.HpHit(Health);
    }
    public void Heal()
    {
        Health++;
        if (Health >= 3)
        {
            Health = 3;
        }
        inGameui.HpHeal(Health-1);
    }
}
