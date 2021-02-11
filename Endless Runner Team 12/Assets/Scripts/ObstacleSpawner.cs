using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField ]private Vector2 timeClamp;
    private float spawnTime;
    private float timer;

    private void Start()
    {
        timer = Random.Range(timeClamp.x, timeClamp.y);
    }
    private void Update() //Activates an obstacle from pool with random position (rotation)
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= timer)
        {
            GameObject obstacle = ObjectPool.instance.GetObstacleFromPool();
            obstacle.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            obstacle.SetActive(true);
            
            spawnTime = 0;
            timer = Random.Range(timeClamp.x, timeClamp.y);
        }
    }
}
