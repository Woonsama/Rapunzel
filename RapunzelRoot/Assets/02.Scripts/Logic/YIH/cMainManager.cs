using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cMainManager : MonoBehaviour
{
    [SerializeField]
    GameObject CreditObject;
    // Start is called before the first frame update
    void Awake()
    {
        CreditObject.SetActive(false);
    }

    public void GameButtonClick()
    {
        SceneManager.LoadScene("InGame");
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void CreditClick()
    {
        CreditObject.SetActive(true);
    }
}
