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

    public GameObject huds;
    public GameObject backgrounds;

    public ItemObject mainItem;

    private void Awake()
    {
        Instance = this;
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

        if (mainItem != null)
        {
            if (mainItem.name == "Pyromancy Staff")
            {
                GameObject pyromancyStaff = GameObject.Find("PyromancyStaffHolding");

                MeshRenderer meshRenderer = pyromancyStaff.GetComponent<MeshRenderer>();

                meshRenderer.enabled = true;
            }

            if (mainItem.name == "Pyromancy Tome")
            {
                GameObject pyromancyTome = GameObject.Find("PyromancyTomeHolding");

                MeshRenderer meshRenderer = pyromancyTome.GetComponent<MeshRenderer>();

                meshRenderer.enabled = true;
            }
        }
    }

    public void OpenInventory()
    {
        backgrounds.SetActive(true);
    }

    public void CloseInventory()
    {
        backgrounds.SetActive(false);
    }

    public void AddItem(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
    }

    public void SetMainItem(ItemObject item)
    {
        mainItem = item;
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

            ItemUIScript itemUIScript = obj.GetComponent<ItemUIScript>();

            itemUIScript.UpdateItem(item);

            itemIcon.sprite = item.icon;
        }
    }
}
