using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cMainManager : MonoBehaviour
{
    [SerializeField]
    GameObject creditObject;

    [Header("Button")]
    public Button button_GameStart;
    public Button button_Credit;
    public Button button_Exit;
    public Button button_Creadit_Exit;
    // Start is called before the first frame update
    void Awake()
    {
        creditObject.SetActive(false);

        button_GameStart.onClick?.AddListener(OnClick_GameButtonClick);
        button_Credit.onClick?.AddListener(OnClick_CreditClick);
        button_Exit.onClick?.AddListener(OnClick_GameExit);
        button_Creadit_Exit.onClick?.AddListener(OnClick_CreaditExit);
    }

    public void OnClick_GameButtonClick()
    {
        SoundManager.Instance.PlayOneShot("Sound/Title/ButtonChooseFinish");
        SceneManager.LoadScene("InGame_Test");
    }
    public void OnClick_GameExit()
    {
        SoundManager.Instance.PlayOneShot("Sound/Title/ButtonChooseFinish");
        Application.Quit();
    }
    public void OnClick_CreditClick()
    {
        SoundManager.Instance.PlayOneShot("Sound/Title/ButtonChooseFinish");
        creditObject.SetActive(true);
    }

    public void OnClick_CreaditExit()
    {
        SoundManager.Instance.PlayOneShot("Sound/Title/ButtonChooseFinish");
        creditObject.SetActive(false);
    }
}
