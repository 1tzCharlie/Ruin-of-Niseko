using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{
    GameObject mainItemSlot;
    public Image itemIcon;

    private void Awake()
    {
        mainItemSlot = GameObject.Find("MainItemIcon");
    }

    public void UpdateImage()
    {
        Image itemImage = mainItemSlot.GetComponent<Image>();

        itemImage.sprite = itemIcon.sprite;
    }
}
