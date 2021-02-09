using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour //Temporary (?) obstacle spawner
{
    private float time = 7;
    private float spawnTime;
    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= time)
        {
            ObjectPool.instance.GetObjectFromPool().SetActive(true);
            spawnTime = 0;
        }
    }
}
