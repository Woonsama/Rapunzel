using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOver : MonoBehaviour
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

	private void OnMouseEnter()
	{
        thisimage.sprite = loloverimage;

    }
	private void OnMouseExit()
	{
        thisimage.sprite = beforeImage;

    }
}
