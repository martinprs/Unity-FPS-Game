using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public float crouchSpeed = 2.5f;

    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    public float standingHeight = 1.8f;
    public float crouchingHeight = 1.0f;
    public float heightChangeSpeed = 6f;

    CharacterController cc;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        cc = gameObject.AddComponent<CharacterController>();
        cc.height = standingHeight;
    }

    void Update()
    {
        isGrounded = cc.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        float currentSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            currentSpeed = sprintSpeed;

        bool crouching = Input.GetKey(KeyCode.LeftControl);
        if (crouching)
            currentSpeed = crouchSpeed;

        cc.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && !crouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        float targetHeight = crouching ? crouchingHeight : standingHeight;
        cc.height = Mathf.Lerp(cc.height, targetHeight, Time.deltaTime * heightChangeSpeed);
    }

    public void Move(bool enabled) {
        if (!enabled) {
            walkSpeed = 0f;
            sprintSpeed = 0f;
            jumpHeight = 0f;
            crouchingHeight = standingHeight;
        }
    }
}