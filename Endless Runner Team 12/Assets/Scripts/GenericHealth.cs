using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float regenRate;
    private float regenTime;
    public int Health { get; private set; }
    public static ObjectPool objectPool;

    private void Awake()
    {
      //  objectPool = this; DIT HIER
    }

    private void Start()
    {
        regenTime += Time.deltaTime;
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

    public void RegenHealth(int amount) //Health regeneration, expand later
    {
        if (isPlayer == true)
        {
            if (true)
            {
                if (regenTime >= regenRate)
                {
                    Health += amount;
                    regenTime = 0f;
                }
            }
        }
    }

    private void Die() //Return object to pool
    {
        // objectPool.destroyObject(); DIT HIER
    }
}
