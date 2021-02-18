using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //Check if hit by object with bullet component, returns both self and, if applicable, object to pool
    {

        if (other.gameObject.GetComponent<Bullet>())
        {
            PlayerManager.instance.ReturnBulletToPool(other.gameObject);
            if (gameObject.GetComponent<EnemyTag>())
            {
                Debug.Log("Hit2");
                ObjectPool.instance.ReturnObject(gameObject);
                SoundManager.instance.PlaySound(SoundManager.SoundType.Kill);
            }
            else
                SoundManager.instance.PlaySound(SoundManager.SoundType.Hit);
        }
    }
}
