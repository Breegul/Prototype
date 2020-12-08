using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float xSensitivity = 5;
    private float ySensitivity = 4;
    public float sensMod;

    private float upRotation = 0;
    private GameObject player;

    public float waterLevel = 70f;
    public Color32 underwaterCol;
    
    void Start()
    {
        player = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked; // hide cursor
        underwaterCol = new Color32(29, 51, 140, 128);
        sensMod = 100f;
    }

    void Update()
    {
        bool isUnderwater = transform.position.y < waterLevel;
        if(!isUnderwater) RenderSettings.fog = false;

        if(isUnderwater)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = underwaterCol;
            RenderSettings.fogDensity = 0.01f;
        }

        // looks up but can't rotate too far
        upRotation -= Input.GetAxis("Mouse Y") * ySensitivity * sensMod * Time.deltaTime;
        upRotation = Mathf.Clamp(upRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(upRotation, 0f, 0f);

        // look around
        float x = Input.GetAxis("Mouse X") * xSensitivity * sensMod * Time.deltaTime;
        player.transform.Rotate(Vector3.up*x);
    }
}
