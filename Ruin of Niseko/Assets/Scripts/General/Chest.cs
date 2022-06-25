using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<ItemObject> possibleItems;

    private Animation anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    private void OnMouseDown()
    {
        anim.Play("ChestOpen");
    }
}
