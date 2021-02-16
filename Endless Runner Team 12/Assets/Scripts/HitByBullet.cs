using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Check if hit by object with bullet component, returns both self and object to pool
    {
        
        if (other.gameObject.GetComponent<Bullet>())
        {
            PlayerManager.instance.ReturnBulletToPool(other.gameObject);
            ObjectPool.instance.ReturnObject(gameObject);
        }
    }
}
