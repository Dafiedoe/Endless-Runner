using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;

    public Vector2 timeClamp;
    private float spawnTime;
    private float timer;

    public delegate void DifficultyEvent(float increase);
    public event DifficultyEvent diffEvent;

    [SerializeField] private float currentSpeed;
    [SerializeField] private Transform obstacleSpawnLocation;

    private void Awake()
    {
        instance = this;
    }

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
            obstacle.GetComponent<Obstacle>().speed = currentSpeed;
            obstacle.transform.position = obstacleSpawnLocation.position;
            obstacle.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            obstacle.SetActive(true);
            
            spawnTime = 0;
            timer = Random.Range(timeClamp.x, timeClamp.y);
        }
    }

    public void CallDifficultyIncrease(float amount)
    {
        diffEvent.Invoke(amount);
        currentSpeed += amount;
    }
}
