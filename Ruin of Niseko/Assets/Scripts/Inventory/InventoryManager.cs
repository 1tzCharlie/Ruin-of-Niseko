using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemObject> items = new List<ItemObject>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject thirdPersonCamera;

    public GameObject huds;
    public GameObject backgrounds;

    private void Awake()
    {
        Instance = this;

        thirdPersonCamera = GameObject.Find("Third Person Camera");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();

            ListItems();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    public void OpenInventory()
    {
        backgrounds.SetActive(true);

        thirdPersonCamera.SetActive(false);
    }

    public void CloseInventory()
    {
        backgrounds.SetActive(false);

        thirdPersonCamera.SetActive(true);
    }

    public void AddItem(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        //Clean Before Open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemIcon.sprite = item.icon;
        }
    }
}
