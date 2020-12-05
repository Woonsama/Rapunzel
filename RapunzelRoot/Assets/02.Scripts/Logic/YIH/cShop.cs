using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cShop : MonoBehaviour
{
    [Header("페이지들")]
    public Sprite[] pages;


    [Header("상점ui")]
    public Image shopui;

    private int nowPage;

    // Start is called before the first frame update
    void Awake()
    {
        nowPage = 0;
    }
    public void NextPageClick()
    {
        nowPage = 1;
        shopui.sprite = pages[nowPage];
    }
    public void PrePageClick()
    {
        nowPage = 0;
        shopui.sprite = pages[nowPage];
    }


}
