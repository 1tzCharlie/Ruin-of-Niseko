using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{
    GameObject mainItemSlot;
    Image itemIcon;

    GameObject inventoryManagerObject;
    InventoryManager inventoryManager;

    ItemObject thisItem;

    private void Awake()
    {
        mainItemSlot = GameObject.Find("MainItemIcon");

        inventoryManagerObject = GameObject.Find("InventoryManager");
        inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
    }

    public void UpdateItemAndImage()
    {
        Image itemImage = mainItemSlot.GetComponent<Image>();

        itemImage.sprite = thisItem.icon;

        inventoryManager.SetMainItem(thisItem);
    }

    public void UpdateItem(ItemObject item)
    {
        thisItem = item;
    }
}
