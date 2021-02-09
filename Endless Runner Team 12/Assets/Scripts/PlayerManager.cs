using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Rigidbody rb;

    [Header("Stats")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float fireRate;
    private float fireTime;

    [Header("Bullet Pool")]
    [SerializeField] private float bulletsInPool;
    [SerializeField] private string bulletName;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private List<GameObject> bullets = new List<GameObject>();

    [Header("Jumping")]
    [SerializeField] private float jumpForce;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Initialize bullet pool
        if (bulletsInPool > 0)
        {
            for (int i = 0; i < bulletsInPool; i++)
            {
                GameObject tempObject = Instantiate(bulletPrefab);
                tempObject.name = bulletName + (i + 1);
                tempObject.SetActive(false);
                bullets.Add(tempObject);
            }
        }
    }

    private void Update()
    {
        // Check for movement
        float xMovement = Input.GetAxisRaw("Horizontal");
        // Applies input to map
        MapRotation.instance.Rotate(new Vector3(0, 0, -xMovement * rotationSpeed * Time.deltaTime));

        // Firing
        fireTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (fireTime >= fireRate)
            {
                GameObject bullet = GetBulletFromPool();
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.GetComponentInChildren<Bullet>().ResetBullet();
                fireTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    // Returns the first object in the bullet pool that's inactive
    GameObject GetBulletFromPool()
    {
        if (bullets.Count <= 0)
        {
            Debug.LogError("Bullet pool is empty");
            return null;
        }

        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeSelf)
            {
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }

        Debug.LogError("All bullets in pool are in use");
        return null;
    }

    // Called to return a bullet back to its pool
    public void ReturnBulletToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);
    }
}
