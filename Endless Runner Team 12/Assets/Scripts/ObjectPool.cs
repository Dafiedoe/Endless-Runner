using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Shamelessly stolen from Bryan van 't Veld, 533712 
{
    public static ObjectPool instance;

    public enum ObstacleType
    {
         tesla,
         pod,
         fence,
         wall,
         pipe
    }

    private List<List<GameObject>> obstaclePool;
    private List<GameObject> teslaPool, podPool, fencePool, wallPool, pipePool;
    private List<GameObject> enemyPool;
    [SerializeField] GameObject prefabTesla, prefabPod, prefabFence, prefabWall, prefabPipe;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] private int setObjectAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GeneratePools();
        GenerateObstacleList();
        GenerateEnemyList();
    }

    void GeneratePools()
    {
        obstaclePool = new List<List<GameObject>>();
        teslaPool = new List<GameObject>();
        podPool = new List<GameObject>();
        fencePool = new List<GameObject>();
        wallPool = new List<GameObject>();
        pipePool = new List<GameObject>();
        obstaclePool.Add(teslaPool);
        obstaclePool.Add(podPool);
        obstaclePool.Add(fencePool);
        obstaclePool.Add(wallPool);
        obstaclePool.Add(pipePool);
    }

    public GameObject GetObstacleFromPool() //retrieves an object from pool
    {
        int randomType = Random.Range(0, obstaclePool.Count);

        for (int i = 0; i < obstaclePool[randomType].Count; i++)
        {
            if (!obstaclePool[randomType][i].activeSelf)
            {
                return obstaclePool[randomType][i];
            }
        }

        Debug.LogError("No objects in pool " + obstaclePool[randomType] + " found!");
        return null;
    }

    public GameObject GetEnemyFromPool() //retrieves an object from pool
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeSelf)
            {
                return enemyPool[i];
            }
        }
        return null;
    }

    public void ReturnObject(GameObject PoolObject) //returns object to pool
    {
        PoolObject.SetActive(false);
    }

    private void PrefabList(GameObject newObject, ObstacleType type) //function for new prefabs obstaclelist
    {
        newObject = Instantiate(newObject);
        newObject.SetActive(false);
        switch (type)
        {
            case ObstacleType.tesla:
                teslaPool.Add(newObject);
                break;
            case ObstacleType.pod:
                podPool.Add(newObject);
                break;
            case ObstacleType.fence:
                fencePool.Add(newObject);
                break;
            case ObstacleType.wall:
                wallPool.Add(newObject);
                break;
            case ObstacleType.pipe:
                pipePool.Add(newObject);
                break;
        }
    }

    private void GenerateObstacleList()
    {
        for (int i = 0; i < setObjectAmount; i++)
        {
            PrefabList(prefabTesla, ObstacleType.tesla);
            PrefabList(prefabFence, ObstacleType.fence);
            PrefabList(prefabPipe, ObstacleType.pipe);
            PrefabList(prefabWall, ObstacleType.wall);
            PrefabList(prefabPod, ObstacleType.pod);
        }
    }

    private void GenerateEnemyList()
    {
        enemyPool = new List<GameObject>(); //creates object pool based on set amount, pool can be extended
        for (int i = 0; i < setObjectAmount; i++)
        {
            GameObject NewEnemy = Instantiate(prefabEnemy);
            NewEnemy.SetActive(false);
            GenericHealth.objectPool = this;
            enemyPool.Add(NewEnemy);
        }
    }
}
