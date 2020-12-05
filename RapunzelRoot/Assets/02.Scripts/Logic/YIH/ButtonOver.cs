using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonOver : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    [Header("롤오버이미지")]
    Sprite loloverimage;

    Image thisimage;

    Sprite beforeImage;
    // Start is called before the first frame update
    void Awake()
    {
        thisimage = GetComponent<Image>();

        beforeImage = thisimage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Instance.PlayOneShot("Sound/Title/ButtonMove");
        thisimage.sprite = loloverimage;

    }
    public void OnPointerExit(PointerEventData eventData)
	{
        thisimage.sprite = beforeImage;

    }
}
