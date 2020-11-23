using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] float turnSmoothVelocity = 2;
    [SerializeField] float turnSmoothTime = 0.1f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.4f;

    [SerializeField] Transform cam;
    
    float gravity = -9.8f;
    Vector3 velocity;

    Vector3 y = Vector3.zero;
    CharacterController characterController;
    PlayerAnimator characterAnimator;

    bool isGround;

    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        groundCheck = transform.GetChild(1);

        characterAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        //Vector3 movement = transform.forward * z * speed + (transform.right * x * 0.5f) + y; //FPS Movement
        characterAnimator.animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude >= 0.1f)
        {
            /*transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation(movement), 0.15f);*/
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            characterAnimator.animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            characterAnimator.animator.SetTrigger("Stopping");
        }
    }
}
