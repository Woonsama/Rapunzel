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

    [Header("Soldouts")]
    public GameObject[] PageSoldOut = new GameObject[4];

    [Header("소비아이템목록")]
    public GameObject[] UseItem = new GameObject[3];

    Player PlayerCode;
    [Header("Button - Exit")]
    public Button button_Exit;

    private bool isClose;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (PlayerCode == null)
        {
            Debug.Log("플레이어못찾음");
        }

        button_Exit.onClick?.AddListener(OnClickExit);
    }
	private void OnEnable()
	{
        PrePageClick();
    }
	public void NextPageClick()
    {
        button_Exit.gameObject.SetActive(true);

        nowPage = 1;
        shopui.sprite = pages[nowPage]; 
        for (int i = 0; i < 4; i++)
        {
            if (DataManager.Instance.PotionLevel[i] >= 2)
            {
                PageSoldOut[i].SetActive(true);
            }
            else
            {
                PageSoldOut[i].SetActive(false);
            }
        }
        UseItem[0].SetActive(false);
        UseItem[1].SetActive(false);
        UseItem[2].SetActive(true);
    }
    public void PrePageClick()
    {
        button_Exit.gameObject.SetActive(false);

        nowPage = 0;
        shopui.sprite = pages[nowPage];
        for (int i = 0; i < 4; i++)
        {
            if (DataManager.Instance.PotionLevel[i] >= 1)
            {
                PageSoldOut[i].SetActive(true);
            }
            else
            {
                PageSoldOut[i].SetActive(false);
            }
        }
        UseItem[0].SetActive(true);
        UseItem[1].SetActive(true);
        UseItem[2].SetActive(false);
    }

    public void Pos1GradeUpgrade(int postiontype)
    {
        if (nowPage == 0)
        {
            if (DataManager.Instance.PotionLevel[postiontype] == 0)
            {
                if (DataManager.Instance.gameData.iGold >= 10)
                {
                    DataManager.Instance.PotionLevel[postiontype] = 1;
                    PageSoldOut[postiontype].SetActive(true);
                    DataManager.Instance.gameData.Do_Add_Or_Minus_Gold(-10);
                }
            }
        }
        else if(nowPage == 1)
        {
            if (DataManager.Instance.PotionLevel[postiontype] == 1)
            {
                if (DataManager.Instance.gameData.iGold >= 30)
                {
                    PageSoldOut[postiontype].SetActive(true);
                    DataManager.Instance.PotionLevel[postiontype] = 2;
                    DataManager.Instance.gameData.Do_Add_Or_Minus_Gold(-30);
                }
            }
        }
    }
    public void HpHeal(int _healvalue)
    {
        if (_healvalue == 1)
        {
            if (DataManager.Instance.gameData.iGold >= 3)
            {
                PlayerCode.Heal();
                DataManager.Instance.gameData.Do_Add_Or_Minus_Gold(-3);
            }
        }
        if (_healvalue == 2)
        {
            if (DataManager.Instance.gameData.iGold >= 7)
            {
                PlayerCode.Heal();
                PlayerCode.Heal();
                DataManager.Instance.gameData.Do_Add_Or_Minus_Gold(-7);
            }
        }
    }
    public void BuyGoldPotion()
    {
        if (DataManager.Instance.gameData.iGold >= 1000)
        {
            DataManager.Instance.iHaveGoldPotionCount++;
            DataManager.Instance.gameData.Do_Add_Or_Minus_Gold(-1000);
        }

    }

    private void OnClickExit()
    {
        this.gameObject.SetActive(false);
    }

}
