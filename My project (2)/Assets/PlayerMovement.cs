
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour 
{
    public float speed = 5f; 
    public float jumpForce = 7f; 
    public float groundCheckRadius = 0.2f;
    public float groundCheck;
    public int whatIsGround;
    
    [SerializeField]private bool isGrounded;
    [SerializeField] CharacterController controller;
    Rigidbody rb; 

    void Start() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate() 
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position,groundCheckRadius,whatIsGround); 
        //isGrounded = Physics.CheckSphere(transform.position,groundCheckRadius,whatIsGround); 

        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(horizontal, 0, vertical); 
        movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * movement; 
        movement = movement.normalized * speed; 
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime); 

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        { 
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}