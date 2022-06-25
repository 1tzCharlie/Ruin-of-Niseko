using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Item/Create New Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject model;

    public Magic magic;

    public int baseDamage;
    public int baseSpeed;

    public bool isStaff;
    public bool isTome;
    public bool isWand;
}

public enum Magic
{
    Pyromancy,
    Cryomancy,
    Necromancy
}
