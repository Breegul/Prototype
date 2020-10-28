using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    private Vector3 velocity;
    private float gravity = -10f;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController cc;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if player is grounded make velocity constant
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundMask);
        if(isGrounded&&velocity.y<0) velocity.y = -1f;

        // (right vector*hInput + forward vector*vInput) * speed
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        cc.Move(move*speed*Time.deltaTime);

        if(isGrounded && Input.GetKey(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // gravity (multiply by time twice because maths)
        velocity.y += gravity*Time.deltaTime;
        cc.Move(velocity*Time.deltaTime);
    }
}
