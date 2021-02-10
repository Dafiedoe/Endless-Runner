using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour //Temporary (?) obstacle spawner
{
    private float time = 7;
    private float spawnTime;
    private void Update() //Activates an obstacle every 7s with random position (rotation)
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= time)
        {
            GameObject obstacle = ObjectPool.instance.GetObstacleFromPool();
            obstacle.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            obstacle.SetActive(true);
            
            spawnTime = 0;
        }
    }
}
