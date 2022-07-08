using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    PlayerMain playerMain;

    public float checkRadius;
    public LayerMask checkLayers;

    public float bulletForce = 15f;

    public LineRenderer lineRenderer;

    EnemyRadar enemyRadar;
    CircleCollider2D radarCollider;

    private void Start()
    {
        playerMain = gameObject.GetComponent<PlayerMain>();

        enemyRadar = GetComponentInChildren<EnemyRadar>();
        radarCollider = enemyRadar.GetComponent<CircleCollider2D>();
        radarCollider.radius = playerMain.equippedSpell.enemyRadarRadius;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        if (playerMain.equippedSpell.isInstantiate)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }

        else if (playerMain.equippedSpell.isRaycast)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

            if (hitInfo && hitInfo.transform.tag == "Hittable" && hitInfo.collider.isTrigger != true)
            {
                Health health = hitInfo.transform.GetComponent<Health>();
                if (health != null)
                {
                    if (playerMain.equippedSpell.secondaryAbility == SecondaryAbilities.Splash)
                    {

                    }

                    else
                    {
                        health.UpdateHealth(-playerMain.equippedSpell.damage);

                        SpriteRenderer spriteRenderer = hitInfo.transform.GetComponent<SpriteRenderer>();
                        spriteRenderer.color = GameController.instance.hitColor;
                        StartCoroutine(ChangeBackColor(hitInfo.transform.gameObject));

                        Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

                        if (enemy == null)
                            yield break;

                        enemy.SetTarget(gameObject);
                    }
                }

                GameObject effect = Instantiate(playerMain.equippedSpell.impactAnim, hitInfo.point, Quaternion.identity);
                Destroy(effect, 1f);

                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);
            }

            lineRenderer.enabled = true;
            yield return new WaitForSeconds(0.05f);
            lineRenderer.enabled = false;
        }

        else if (playerMain.equippedSpell.secondaryAbility == SecondaryAbilities.Closest)
        {
            if (enemyRadar.enemyContact)
            {
                if (enemyRadar.closestEnemy.gameObject.tag == "Hittable")
                {
                    Health collisionHealth = enemyRadar.closestEnemy.gameObject.GetComponent<Health>();

                    if (collisionHealth == null)
                        yield break;

                    collisionHealth.UpdateHealth(-playerMain.equippedSpell.damage);

                    SpriteRenderer spriteRenderer = enemyRadar.closestEnemy.gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.color = GameController.instance.hitColor;
                    StartCoroutine(ChangeBackColor(enemyRadar.closestEnemy.gameObject));

                    Enemy enemy = enemyRadar.closestEnemy.gameObject.GetComponent<Enemy>();

                    if (enemy == null)
                        yield break;

                    enemy.SetTarget(gameObject);
                }
            }

            else
            {
                CinemachineShake.instance.ShakeCamera(1f, 0.15f);
            }
        }

        else if (playerMain.equippedSpell.secondaryAbility == SecondaryAbilities.Teleport)
        {
            if (enemyRadar.enemyContact)
            {
                if (enemyRadar.closestEnemy.gameObject.tag == "Hittable")
                {
                    Health collisionHealth = enemyRadar.closestEnemy.gameObject.GetComponent<Health>();

                    if (collisionHealth == null)
                        yield break;

                    collisionHealth.UpdateHealth(-playerMain.equippedSpell.damage);

                    SpriteRenderer spriteRenderer = enemyRadar.closestEnemy.gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.color = GameController.instance.hitColor;
                    StartCoroutine(ChangeBackColor(enemyRadar.closestEnemy.gameObject));

                    Enemy enemy = enemyRadar.closestEnemy.gameObject.GetComponent<Enemy>();

                    if (enemy == null)
                        yield break;

                    Vector3 enemyPosition = enemy.gameObject.transform.position;
                    enemy.canAttack = 0.5f;
                    gameObject.transform.position = enemyPosition;
                    if (enemy != null)
                    {
                        enemy.SetTarget(gameObject);
                    }
                }
            }

            else
            {
                CinemachineShake.instance.ShakeCamera(1f, 0.15f);
            }
        }

        else
            Debug.LogError("Spell fire type not set");
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
