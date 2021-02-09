using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth; //set starting health individually in Unity Inspector
    public int Health { get; private set; } //other scripts can set value

    private void Start()
    {
        Health = startingHealth;
    }

    public void TakeDamage(int damage) //Method can be called in other scripts to deal damage to entity's health
    {
        Health = Mathf.Clamp(Health - damage, 0, startingHealth);
        if (Health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); //revise if necessary to prevent CTD
    }
}
