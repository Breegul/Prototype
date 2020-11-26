using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPlatform : MonoBehaviour
{
    private float distanceWalked;
    public float changeDir;

    private Vector3 direction;
    public float speed;
    private Vector3 movement;

    void Start()
    {
        direction = new Vector3(1, 0, 0);
    }

    void FixedUpdate()
    {
        if(distanceWalked >= changeDir)
        {
            distanceWalked = 0f;
            direction = -direction;
        }
        movement = direction*speed*Time.deltaTime;

        transform.position += movement;

        distanceWalked += speed*Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
