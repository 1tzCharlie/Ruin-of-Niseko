using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public int maxHealth = 50;
    public int currHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;

        healthBar.SetHealth(currHealth);
    }
}
