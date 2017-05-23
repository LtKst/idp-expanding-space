using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildRotation : MonoBehaviour
{

    Quaternion rotation;

    private void Start()
    {
        rotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = rotation;
    }
}
