using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3 startLocation;

    private void Update()
    {
        // Moves the bullet at the given speed
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    public void ResetBullet()
    {
        transform.localPosition = startLocation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Background"))
        {
            PlayerManager.instance.ReturnBulletToPool(transform.parent.gameObject);
        }
    }
}
