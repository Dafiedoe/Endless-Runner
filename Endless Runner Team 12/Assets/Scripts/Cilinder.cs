using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilinder : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float removeLocation;

    private void Update()
    {
        // Moves the map part at the given speed
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);

        if (transform.position.z <= removeLocation)
            CilinderManager.instance.ReturnToPool(gameObject);
    }
}
