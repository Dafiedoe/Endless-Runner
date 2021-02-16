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

    [SerializeField] private Transform bulletParent;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sliding")]
    [SerializeField] private bool isSliding;
    [SerializeField] private float slideTimer;
    private float slideTime;
    [SerializeField] private Vector3 regularRotation;
    [SerializeField] private Vector3 slidingRotation;

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
                tempObject.transform.parent = bulletParent;
                tempObject.SetActive(false);
                bullets.Add(tempObject);
            }
        }
    }

    private void Update()
    {
        // Check for movement
        float xMovement = Input.GetAxisRaw("Horizontal");
        // Applies input to player
        if (!isSliding)
            MapRotation.instance.Rotate(new Vector3(0, 0, xMovement * rotationSpeed * Time.deltaTime));

        // Firing
        fireTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (fireTime >= fireRate)
            {
                GameObject bullet = GetBulletFromPool();
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                fireTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isSliding)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isGrounded && !isSliding)
        {
            transform.Rotate(slidingRotation);
            isSliding = true;
            //transform.position += new Vector3(0f, 3.5f, 0f);
        }

        if (isSliding)
        {
            slideTime += Time.deltaTime;
            if (slideTime >= slideTimer)
            {
                transform.Rotate(regularRotation);
                isSliding = false;
                slideTime = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(feet.position, -Vector3.up, .5f, groundLayer);
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

    private void OnTriggerEnter(Collider other)
    {
        GenericHealth playerHealth = GetComponent<GenericHealth>();
        if (other.gameObject.GetComponent<CollisionTag>())
        {
            playerHealth.TakeDamage(-1);
            playerHealth.RegenHealth(+1);
        }

        if (other.CompareTag("Killbox"))
        {
            playerHealth.TakeDamage(-int.MaxValue);
            Debug.Log("Player died");
        }
    }
}
