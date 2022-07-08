using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    GameObject player;
    PlayerMain playerMain;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerMain = player.GetComponent<PlayerMain>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tilemap")
        {
            SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
            thisSpriteRenderer.enabled = false;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject, 1f);
        }

        if (collision.gameObject.name == "Player")
            return;

        if (collision.gameObject.tag == "Hittable")
        {
            Health collisionHealth = collision.gameObject.GetComponent<Health>();
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (collisionHealth == null)
                return;

            if (playerMain.equippedSpell.secondaryAbility == SecondaryAbilities.Poison)
            {
                if (collisionHealth.isPoisoned == false)
                {
                    collisionHealth.PoisonStart(collisionHealth, playerMain);
                    SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
                    thisSpriteRenderer.enabled = false;
                    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 1f);
                    Destroy(gameObject, 1f);
                    enemy.SetTarget(player);

                    collisionHealth.isPoisoned = true;
                    return;
                }

                if (collisionHealth.isPoisoned == true)
                {
                    SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
                    thisSpriteRenderer.enabled = false;
                    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 1f);
                    Destroy(gameObject, 1f);
                    enemy.SetTarget(player);

                    return;
                }
            }

            collisionHealth.UpdateHealth(-playerMain.equippedSpell.damage);

            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GameController.instance.hitColor;
            StartCoroutine(ChangeBackColor(collision.gameObject));

            if (enemy == null)
                return;

            enemy.SetTarget(player);
        }
    }

    public IEnumerator ChangeBackColor(GameObject collision)
    {
        yield return new WaitForSeconds(0.5f);
        if (collision == null)
            yield break;

        SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameController.instance.defaultColor;
    }
}
