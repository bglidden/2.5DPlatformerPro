using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float speed;

    private Transform currentDestination;

    private void Start()
    {
        // assume we're starting at PointA
        currentDestination = pointB;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position,
            speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) < 0.001f)
        {
            if (currentDestination == pointA)
            {
                currentDestination = pointB;
            }
            else
            {
                currentDestination = pointA;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
