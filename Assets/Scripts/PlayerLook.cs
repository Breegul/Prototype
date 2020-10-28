using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;

    private float upRotation = 0;
    private GameObject player;
    
    void Start()
    {
        player = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked; // hide cursor
    }

    void Update()
    {
        // looks up but can't rotate too far
        upRotation -= Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        upRotation = Mathf.Clamp(upRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(upRotation, 0f, 0f);

        // look around
        float x = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        player.transform.Rotate(Vector3.up*x);
    }
}
