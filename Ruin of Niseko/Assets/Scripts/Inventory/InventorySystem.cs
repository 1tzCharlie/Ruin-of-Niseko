using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject huds;
    public GameObject backgrounds;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    public void OpenInventory()
    {
        huds.SetActive(false);
        backgrounds.SetActive(true);
    }

    public void CloseInventory()
    {
        huds.SetActive(true);
        backgrounds.SetActive(false);
    }
}
