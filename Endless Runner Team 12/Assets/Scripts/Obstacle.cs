using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObjectPool.ObstacleType type;
    public float speed;
    [SerializeField] private float removeLocation;

    private void Start() //spawn location set down the cyllinder
    {
        ObstacleSpawner.instance.diffEvent += IncreaseDifficulty;
    }

    private void Update()
    {
        // Moves the obstacle part at the given speed
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);

        if (transform.position.z <= removeLocation)
            ObjectPool.instance.ReturnObject(gameObject);
    }

    public void IncreaseDifficulty(float amount)
    {
        speed += amount;
    }
}
