using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentByRB : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] private float speed;
    public float HorizontalMovment;
    private float VerticalMovment;
    private Vector3 MoveDirection;
    [Header("AirControl")]
    [SerializeField] private float AirSpeed;
    [Header("Jump")]
    [SerializeField] private float jumpforce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool IsGrounded;
    [Header("Crouch")]
    [SerializeField] private float crouchforce;
    [SerializeField] private bool IsCrouching=false;
    

    private Rigidbody Rigidbody;


    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Imputs();
    }

    private void Imputs()
    {
        HorizontalMovment = Input.GetAxisRaw("Horizontal");
        VerticalMovment = Input.GetAxisRaw("Vertical");

        MoveDirection = transform.forward * VerticalMovment + transform.right * HorizontalMovment; 
    }

    private void FixedUpdate()
    {
        if (IsGrounded == true)
        {
            Movment();
            Jump();
            Crouch();//?
        }
        else if (IsGrounded==false)
        {
            AirControl();
        }
    }

    private void Movment()
    {
        Rigidbody.velocity = MoveDirection.normalized * speed;
    }
    private void AirControl()
    {
        Rigidbody.AddForce(MoveDirection.normalized* AirSpeed, ForceMode.Acceleration);
    }
    private void Jump()
    {
        if (Input.GetButton("Jump")) 
        {
            Rigidbody.AddForce(Vector2.up * jumpforce,ForceMode.Impulse);
        }
    }
    private void Crouch()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = !IsCrouching;
            if (IsCrouching==false)
            {
                transform.localScale *= 2;
            }
            else if(IsCrouching==true)
            {
                transform.localScale /= 2;
            }
        }
        
    }
   
}
