﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMove : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = transform.Find("WhaleTarget").transform;
    }

    void FixedUpdate()
    {
        transform.RotateAround(target.position, Vector3.up, 20*Time.deltaTime);
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
