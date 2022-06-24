using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemObject item;
    GameObject inventoryManagerObject;
    InventoryManager inventoryManager;

    public void Awake()
    {
        inventoryManagerObject = GameObject.Find("InventoryManager");
        inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
    }

    public void Pickup()
    {
        inventoryManager.AddItem(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
