using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health = 0f;
    public bool isPoisoned = false;
    [SerializeField] private float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0f)
        {
            health = 0f;
            Destroy(gameObject);
        }
    }

    public void PoisonStart(Health collisionHealth, PlayerMain player)
    {
        StartCoroutine(collisionHealth.PoisonDamage(player));
    }

    public IEnumerator PoisonDamage(PlayerMain player)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateHealth(-player.equippedSpell.poisonDamage);

        spriteRenderer.color = GameController.instance.poisonColor;
        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = GameController.instance.defaultColor;
        yield return new WaitForSeconds(0.5f);

        UpdateHealth(-player.equippedSpell.poisonDamage);

        spriteRenderer.color = GameController.instance.poisonColor;
        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = GameController.instance.defaultColor;
        yield return new WaitForSeconds(0.5f);

        UpdateHealth(-player.equippedSpell.poisonDamage);

        spriteRenderer.color = GameController.instance.poisonColor;
        yield return new WaitForSeconds(0.5f);

        spriteRenderer.color = GameController.instance.defaultColor;

        isPoisoned = false;
    }
}
