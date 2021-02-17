using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    
    [SerializeField] private Vector2 timeClamp;
    private float spawnTime;
    private float timer;

    public delegate void DifficultyEvent(float increase);
    public event DifficultyEvent diffEvent;

    [SerializeField] private float currentSpeed;
    [SerializeField] private Transform obstacleSpawnLocation;

    private void Awake() //singleton
    {
        instance = this;
    }

    private void Start() //spawn time randomizer
    {
        timer = Random.Range(timeClamp.x, timeClamp.y);
    }
    private void Update() //Activates an enemy from pool with fixed pos, random position rotation and increasing speed
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= timer)
        {
            GameObject enemy = ObjectPool.instance.GetEnemyFromPool();
            enemy.GetComponent<Obstacle>().speed = currentSpeed;
            enemy.transform.position = obstacleSpawnLocation.position;
            enemy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            enemy.SetActive(true);

            spawnTime = 0;
            timer = Random.Range(timeClamp.x, timeClamp.y);
        }
    }

    public void CallDifficultyIncrease(float amount) //handles difficulty over time
    {
        diffEvent.Invoke(amount);
        currentSpeed += amount;
    }
}
