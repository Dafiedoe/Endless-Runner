using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    public int Health { get; private set; }

    private void Start()
    {
        Health = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, startingHealth);
        if (Health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
