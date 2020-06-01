using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smothSpeed = 1f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 startposition = new Vector3(target.position.x, 5, -1f);
        Vector3 smothposition = Vector3.Lerp(transform.position, startposition, smothSpeed);
        transform.position = smothposition;
    }
}