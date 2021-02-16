using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Shamelessly stolen from Bryan van 't Veld, 533712 
{
    public static ObjectPool instance;

    private List<GameObject> obstaclePool;
    private List<GameObject> enemyPool;
    [SerializeField] GameObject prefabTesla;
    [SerializeField] GameObject prefabPod;
    [SerializeField] GameObject prefabFence;
    [SerializeField] GameObject prefabWall;
    [SerializeField] GameObject prefabPipe;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] private int setObjectAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateObstacleList();
        GenerateEnemyList();
    }

    public GameObject GetObstacleFromPool() //retrieves an object from pool
    {
        for (int i = 0; i < obstaclePool.Count; i++)
        {
           if (!obstaclePool[i].activeSelf)
            {
                return obstaclePool[i];
            }
        }
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

    private void PrefabList(GameObject newObject) //function for new prefabs obstaclelist
    {
        newObject = Instantiate(newObject);
        newObject.SetActive(false);
        obstaclePool.Add(newObject);
    }

    private void GenerateObstacleList()
    {
        obstaclePool = new List<GameObject>(); //creates object pool based on set amount, pool can be extended
        for (int i = 0; i < setObjectAmount; i++)
        {
            PrefabList(prefabTesla);
            PrefabList(prefabFence);
            PrefabList(prefabPipe);
            PrefabList(prefabWall);
            PrefabList(prefabPod);
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
