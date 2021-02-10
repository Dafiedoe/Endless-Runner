using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float removeLocation;
    [SerializeField] private Vector3 spawnLocation;

    private void Start()
    {
        transform.position = spawnLocation;
    }

    private void Update()
    {
        // Moves the obstacle part at the given speed
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);

        if (transform.position.z <= removeLocation)
            ObjectPool.instance.ReturnObject(gameObject);
    }
}
