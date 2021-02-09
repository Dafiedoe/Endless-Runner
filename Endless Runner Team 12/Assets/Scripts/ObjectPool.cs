using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Shamelessly stolen from Bryan van 't Veld, 533712 
{
    private List<GameObject> objectPool;
    [SerializeField] GameObject prefabExample; //every pool object needs to be a prefab GameObject
    [SerializeField] private int setObjectAmount;

    private void Start()
    {
        objectPool = new List<GameObject>(); //creates object pool based on set amount, pool can be extended
        for (int i = 0; i < setObjectAmount; i++)
        {
            GameObject SetNewPool = Instantiate(prefabExample);
            SetNewPool.SetActive(false);
            objectPool.Add(prefabExample);
        }
    }
    public GameObject GetObjectFromPool() //retrieves an object from pool
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
           if(!objectPool[i].activeSelf)
            {
                return objectPool[i];
            }
        }
        return null;
    }
    public void destroyObject(GameObject PoolObject, GameObject SetNewPool) //returns object to pool
    {
        SetNewPool.SetActive(false);
    }
}
