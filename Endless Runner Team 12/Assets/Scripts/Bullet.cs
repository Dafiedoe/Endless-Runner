using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        // Moves the bullet at the given speed
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            PlayerManager.instance.ReturnBulletToPool(gameObject);
        }
    }
}
