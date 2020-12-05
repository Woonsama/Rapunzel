using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumData.ColorType;

[System.Serializable]
public class Liquor :ObjectBase
{
    [Header("Potion Color Type")]
    public EPotionColorType ePotioColorType;

    const float c_MoveSpeed = 2.0f;
    const int c_Max_ReinForceCount = 3;

    [SerializeField]
    [Header("Images")]
    public Sprite[] potion = new Sprite[3];

   // public int level = 1;
    public int[] damage = new int[c_Max_ReinForceCount];
    public int[] price = new int[c_Max_ReinForceCount];
    public Sprite liquor_Full;

    private Image image;

    private Vector3 originPos;
    private float angle;

    protected override IEnumerator OnAwakeCoroutine()
    {
        angle = GameObject.Find("Shooter").transform.GetChild(1).transform.eulerAngles.z;
        SetOriginalPos();
        image = GetComponent<Image>();
        image.sprite = potion[DataManager.Instance.PotionLevel[(int)ePotioColorType]];
        return base.OnAwakeCoroutine();
    }

    private void Update()
    {
        MoveTo();
    }

    public void ChangeImage_Full()
    {
        image.sprite = liquor_Full;
    }

    private int GetDamage()
    {
        return damage[DataManager.Instance.PotionLevel[(int)ePotioColorType] + 1];
    }

    private void SetOriginalPos()
    {
        originPos = transform.position;
    }

    Vector3 movePower;

    private void MoveTo()
    {
        movePower = Quaternion.AngleAxis(angle, Vector3.forward) * new Vector3(0, -c_MoveSpeed, 0) * Time.deltaTime;
        transform.position += movePower;
    }
}
