using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInGameUi : MonoBehaviour
{
    [SerializeField]
    private Text m_txtScoreText;
    [SerializeField]
    private Text m_txtMoneyText;
    [SerializeField]
    private GameObject[] m_goHps;

    [SerializeField]
    private Sprite m_imgHpempty;

    [SerializeField]
    private Sprite m_imgHpFull;

    [Header("Button - SoundOnOff")]
    public Button button_SoundOnOff;

    [Header("Sprite - SoundOnOff")]
    public Sprite soundOn;
    public Sprite soundOff;

    [Header("Command")]
    public Command command;

    [Header("Child Command Layer")]
    public Child layer;

    [Header("Command Prefab")]
    public Sprite[] commandSprite = new Sprite[4];

    private void Awake()
	{
        Init();
	}


    public void Init()
    {
        layer.GetChildGameObject();

        for (int i = 0; i < m_goHps.Length; i++)
        {
            m_goHps[i].GetComponent<Image>().sprite = m_imgHpFull;
        }

        //SoundButton
        button_SoundOnOff.onClick?.AddListener(OnClickSoundOnOff);

        SetCommand();
    }

    public void SetScoreText(int _value)
    {
        m_txtScoreText.text = _value.ToString();
    }
    public void SetMoneyText(int _value)
    {
        m_txtMoneyText.text = _value.ToString();
    }
    public void HpHit(int _index)
    {
        m_goHps[_index].GetComponent<Image>().sprite = m_imgHpempty;
    }
    public void HpHeal(int _index)
    {
            m_goHps[_index].GetComponent<Image>().sprite = m_imgHpFull;
    }
    private void Update()
	{
        SetScoreText(DataManager.Instance.gameData.iScore);
        SetMoneyText(DataManager.Instance.gameData.iGold);
    }
    

    #region private

    private void OnClickSoundOnOff()
    {
        if(SoundManager.Instance.isSoundOn)
        {
            button_SoundOnOff.GetComponent<Image>().sprite = soundOff;
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PauseOneShot();
        }
        else
        {
            SoundManager.Instance.PlayBGM();
            button_SoundOnOff.GetComponent<Image>().sprite = soundOn;
        }

        SoundManager.Instance.isSoundOn = !SoundManager.Instance.isSoundOn;
    }

    public void SetCommand()
    {
        for(int i = 0; i < command.str_LiquorCombo.Length; i++)
        {
            for(int j = 0; j < command.str_LiquorCombo[i].Length; j++)
            {
                if (command.str_LiquorCombo[i][j] == 'Q')
                    layer.child[i].transform.GetChild(0).GetChild(j).GetComponent<Image>().sprite = commandSprite[0];

                if (command.str_LiquorCombo[i][j] == 'W')
                    layer.child[i].transform.GetChild(0).GetChild(j).GetComponent<Image>().sprite = commandSprite[1];

                if (command.str_LiquorCombo[i][j] == 'E')
                    layer.child[i].transform.GetChild(0).GetChild(j).GetComponent<Image>().sprite = commandSprite[2];

                if (command.str_LiquorCombo[i][j] == 'R')
                    layer.child[i].transform.GetChild(0).GetChild(j).GetComponent<Image>().sprite = commandSprite[3];
            }
        }
    }

    public void AddCommand(int first, int second)
    {
        if (command.str_LiquorCombo[first][second] == 'Q')
            layer.child[first].transform.GetChild(0).GetChild(second).GetComponent<Image>().sprite = commandSprite[0];

        if (command.str_LiquorCombo[first][second] == 'W')
            layer.child[first].transform.GetChild(0).GetChild(second).GetComponent<Image>().sprite = commandSprite[1];

        if (command.str_LiquorCombo[first][second] == 'E')
            layer.child[first].transform.GetChild(0).GetChild(second).GetComponent<Image>().sprite = commandSprite[2];

        if (command.str_LiquorCombo[first][second] == 'R')
            layer.child[first].transform.GetChild(0).GetChild(second).GetComponent<Image>().sprite = commandSprite[3];

    }

    #endregion private

}
