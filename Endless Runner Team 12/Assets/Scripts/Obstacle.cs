using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObjectPool.ObstacleType type;
    [SerializeField] private float speed;
    [SerializeField] private float removeLocation;
    [SerializeField] private Vector3 spawnLocation;

    private void Start() //spawn location set down the cyllinder
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
