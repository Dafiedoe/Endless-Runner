using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            ObjectPool.instance.ReturnObject(gameObject);
        }
    }
}
