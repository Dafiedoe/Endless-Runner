using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMap : MonoBehaviour
{
    private void Start()
    {
        MapRotation.instance.objectsToRotate.Add(transform);
    }
}
