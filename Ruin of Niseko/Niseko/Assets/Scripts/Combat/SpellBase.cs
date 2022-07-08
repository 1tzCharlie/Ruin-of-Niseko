using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Combat/New Spell")]
public class SpellBase : ScriptableObject
{
    [Header("Common Attributes")]
    [Space]
    [SerializeField] public string spellName;
    [SerializeField] public string description;

    [Header("Damage")]
    [Space]
    [SerializeField] public int damage = 1;
    [SerializeField] public int speed = 1;

    [Header("Magic Type")]
    [Space]
    [SerializeField] public bool isDefaultSpell;
    [SerializeField] public bool isPyromancy;
    [SerializeField] public bool isCryomancy;
    [SerializeField] public bool isNecromancy;
    [SerializeField] public bool isVoodoo;
    [SerializeField] public bool isAthamancy;

    [Header("Fire Type")]
    [Space]
    [SerializeField] public bool isInstantiate;
    [SerializeField] public GameObject bullet;
    [Space]
    [SerializeField] public bool isRaycast;
    [SerializeField] public GameObject spellAnim;
    [Space]
    [SerializeField] public GameObject impactAnim;

    [Header("Secondary Abilities")]
    [SerializeField] public SecondaryAbilities secondaryAbility;
    [Space]
    [SerializeField] public int poisonDamage;
    [SerializeField] public int enemyRadarRadius;
    [SerializeField] public int controlTime;
    [SerializeField] public int leechHealth;
}

public enum SecondaryAbilities
{
    None,
    Splash,
    Leech,
    Heal,
    Summon,
    Control,
    Teleport,
    Poison,
    Closest
}