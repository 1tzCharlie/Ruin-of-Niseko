using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackSpeed = 1.5f;
    public float canAttack = 1;
    private Transform target;

    bool isBeside;

    private void Update()
    {
        if (target != null)
        {
            if (isBeside)
            {
                float step = speed / 200f * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            }
        }

        if (canAttack < 1)
        {
            canAttack += Time.deltaTime;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            target = collision.transform;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isBeside = true;

            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerMain>().UpdateHealth(-attackDamage);
                SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.color = GameController.instance.hitColor;
                StartCoroutine(ChangeBackColor(collision.gameObject));

                canAttack = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isBeside = false;
    }

    public IEnumerator ChangeBackColor(GameObject collision)
    {
        yield return new WaitForSeconds(0.5f);
        SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameController.instance.defaultColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            target = null;
        }
    }
}
