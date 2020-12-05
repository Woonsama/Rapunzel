using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Liquor :ObjectBase
{
    const int c_Max_ReinForceCount = 3;

    public int level;
    public int[] damage = new int[c_Max_ReinForceCount];
    public int[] price = new int[c_Max_ReinForceCount];
    public Sprite liquor_Full;

    private Image image;

    public Liquor()
    {
        image = GetComponent<Image>();
        level = 1;
    }

    public void ChangeImage_Full()
    {
        image.sprite = liquor_Full;
    }

    private int GetDamage()
    {
        return damage[level - 1];
    }

    public void LevelUp()
    {
        level++;
    }
}
