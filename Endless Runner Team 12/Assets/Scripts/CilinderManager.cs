using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilinderManager : MonoBehaviour
{
    public static CilinderManager instance;

    [SerializeField] private int amount;
    [SerializeField] private string poolObjectName;
    [SerializeField] private Vector3 spawnLocation;
    [SerializeField] private Vector3[] firstSpawns;

    [SerializeField] private GameObject cilinderPrefab;
    [SerializeField] private List<GameObject> cilinders = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Initializes the cilinder pool
        for (int i = 0; i < amount; i++)
        {
            GameObject tempObject = Instantiate(cilinderPrefab);
            tempObject.name = poolObjectName + (i + 1);
            tempObject.SetActive(false);
            cilinders.Add(tempObject);
        }
        // Spawns the first few cilinders
        for (int i = 0; i < firstSpawns.Length; i++)
        {
            GameObject cilinder = GetObjectFromPool();
            cilinder.transform.position = firstSpawns[i];
            cilinder.SetActive(true);
        }
    }

    // Returns the first inactive cilinder in the pool
    public GameObject GetObjectFromPool()
    {
        if (cilinders.Count <= 0)
        {
            Debug.LogError("Pool is empty");
            return null;
        }

        for (int i = 0; i < cilinders.Count; i++)
        {
            if (!cilinders[i].activeSelf)
            {
                return cilinders[i];
            }
        }

        Debug.LogError("All pooling objects are in use");
        return null;
    }

    // Called to return a cilinder back to its pool
    public void ReturnToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);

        GameObject cilinder = GetObjectFromPool();
        cilinder.transform.position = spawnLocation;
        cilinder.SetActive(true);
    }
}
