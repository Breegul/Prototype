using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //TODO: set a maximum for hook speed
    //TODO: tweak all the multipliers and drag and stuff
    //TODO: if you go into a wall with high momentum you keep getting pushed into it, fix (if velocity.magnitude < 1: momentum = 0)?
    //class variables marked with // are only public for testing, should be made private
    public float speed;
    public float jumpHeight;

    public Vector3 velocity; //
    private float yVelocity;
    private Vector3 momentum;
    public float momentumDrag;
    public float momentumMultiplier;

    private float gravity = -10f;
    public bool isGrounded; //
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController cc;
    private Camera pCamera;

    private State state; //
    private enum State
    {
        Normal,
        Hooked
    }
    public GameObject testBox;
    private Vector3 hookPos;
    public float hookSpeedMultiplier;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        pCamera = transform.Find("Camera").GetComponent<Camera>();
        state = State.Normal;
    }

    void Update()
    {
        switch (state)
        {
            case State.Normal:
                GroundMovement();
                break;
            case State.Hooked:
                HookMovement();
                break;
        }

        HookStart();
    }

    private void GroundMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundMask);

        // (right vector*hInput + forward vector*vInput) * speed
        velocity = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed;

        //if player is grounded make velocity constant, player can jump while grounded
        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // gravity, multiply by time twice because maths, also yVelocity because otherwise it gets reset
        yVelocity += gravity * Time.deltaTime;
        velocity.y = yVelocity;

        // apply momentum then dampen it 
        velocity += momentum;
        if (momentum.magnitude > 0f)
        {
            momentum -= momentum * momentumDrag * Time.deltaTime;
            if (momentum.magnitude < 0.1f)
            {
                momentum = Vector3.zero;
            }
        }

        cc.Move(velocity * Time.deltaTime);
    }

    private void HookStart()
    {
        // Casts a ray, if it hits player is hooked
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(pCamera.transform.position, pCamera.transform.forward, out RaycastHit raycastHit))
            {
                testBox.transform.position = raycastHit.point;
                hookPos = raycastHit.point;
                state = State.Hooked;
            }
        }
    }

    private void HookMovement()
    {
        Vector3 hookDir = (hookPos - transform.position).normalized;
        float hookSpeed = Vector3.Distance(transform.position, hookPos);

        cc.Move(hookDir * hookSpeed * hookSpeedMultiplier * Time.deltaTime);

        // Hook done when distance to hookPos < 1.5f (if it's too low gets stuck on some slants)
        // or when player clicks again
        if (Vector3.Distance(transform.position, hookPos) < 1.5f || Input.GetMouseButtonDown(0))
        {
            state = State.Normal;
            yVelocity = 0;
        }

        // add momentum on jump, based on hookDir, current hookSpeed, and a multiplier
        // also adds a little vertical boost, currently double usual jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            momentum = hookDir * hookSpeed * momentumMultiplier;
            momentum += Vector3.up * 2 * Mathf.Sqrt(jumpHeight * -2f * gravity);
            state = State.Normal;
            yVelocity = 0;
        }
    }
}
