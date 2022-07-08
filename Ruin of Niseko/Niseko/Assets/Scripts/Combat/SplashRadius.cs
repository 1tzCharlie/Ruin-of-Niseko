using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashRadius : MonoBehaviour
{
    CircleCollider2D splashCollider;

    private void Awake()
    {
        splashCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health collisionHealth = collision.GetComponent<Health>();
    }
}
