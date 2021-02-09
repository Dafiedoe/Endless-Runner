using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Shamelessly stolen from Bryan van 't Veld, 533712 
{
    public static ObjectPool instance;
    
    private List<GameObject> objectPool;
    [SerializeField] GameObject prefabObstacle;
    [SerializeField] private int setObjectAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectPool = new List<GameObject>(); //creates object pool based on set amount, pool can be extended
        for (int i = 0; i < setObjectAmount; i++)
        {
            GameObject SetNewPool = Instantiate(prefabObstacle);
            SetNewPool.SetActive(false);
            GenericHealth.objectPool = this;
            objectPool.Add(prefabObstacle);
        }
    }

    public GameObject GetObjectFromPool() //retrieves an object from pool
    {
        if (objectPool.Count == 0)
        {
            Debug.LogError("Empty");
        }
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeSelf)
            {
                return objectPool[i];
            }
        }
        return null;
    }

    public void returnObject(GameObject PoolObject) //returns object to pool
    {
        PoolObject.SetActive(false);
    }
}
