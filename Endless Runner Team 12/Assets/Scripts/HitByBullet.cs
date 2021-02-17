using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Check if hit by object with bullet component, returns both self and, if applicable, object to pool
    {
        
        if (other.gameObject.GetComponent<Bullet>())
        {
            Debug.Log("Hit1");
            PlayerManager.instance.ReturnBulletToPool(other.gameObject);
            if (other.gameObject.GetComponent<EnemyTag>())
            {
                Debug.Log("Hit2");
                ObjectPool.instance.ReturnObject(gameObject);
            }
        }
    }
}
