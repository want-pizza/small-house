using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    private int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}
