using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    public static MapRotation instance;

    public List<Transform> objectsToRotate = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    public void Rotate(Vector3 rotation)
    {
        foreach (Transform objectToRotate in objectsToRotate)
        {
            objectToRotate.Rotate(rotation);
        }
    }
}
