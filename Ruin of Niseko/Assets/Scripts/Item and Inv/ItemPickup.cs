using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public ItemObject item;
    GameObject inventoryManagerObject;
    InventoryManager inventoryManager;

    public GameController gameController;
    public GameObject UI;
    public Image UIBackground;
    public Text itemName;
    public Text damage;
    public Text speed;

    public void Awake()
    {
        inventoryManagerObject = GameObject.Find("InventoryManager");
        inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (item.magic == Magic.Pyromancy)
        {
            UIBackground.color = gameController.pyromancyUIBackground;
        }

        if (item.magic == Magic.Cryomancy)
        {
            UIBackground.color = gameController.cryomancyUIBackground;
        }

        if (item.magic == Magic.Necromancy)
        {
            UIBackground.color = gameController.necromancyUIBackground;
        }

        itemName.text = item.itemName;
        damage.text = item.baseDamage.ToString();
        speed.text = item.baseSpeed.ToString();
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
