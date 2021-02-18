using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private bool isPlayer;
    private bool invulnerable;

    public int Health { get; private set; }
    public static ObjectPool objectPool;

    private void Start()
    {
        Health = startingHealth;
        invulnerable = false;
    }

    public void TakeDamage(int damage) //Method can be called in other scripts to deal damage to entity's health
    {
        Health += damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void RegenHealth(int amount) //Health regeneration check
    {
        if (!gameObject) return;

        if (isPlayer == true)
        {
            if (startingHealth > Health)
            {
                StartCoroutine("Cooldown", amount);
                //StartCoroutine("Invulnerable"); - needs testing/fixing
            }
        }
    }

    IEnumerator Cooldown(int amount) //Health regen and cooldown
    {
        yield return new WaitForSeconds(7);
        Health += amount;
    }

    IEnumerator Invulnerable(int amount) //Invulnerability upon receiving damage - needs testing/fixing
    {
        yield return new WaitForSeconds(4);
        //make player flicker
        invulnerable = false;
    }

    private void Die() //Return object to pool
    {
        objectPool.ReturnObject(gameObject);
        GameManager.instance.GameOver();
    }
}
