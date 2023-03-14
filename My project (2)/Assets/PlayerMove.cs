using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float shift;
    [SerializeField] Animator anim;
    private Vector3 direction;
    
    
    void Start()
    {

    }    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                //direction.y = -shift;
                controller.height = 1.0f;
            }
            else 
            {
                controller.height = 2.0f;
            }
        }
        
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("atac",true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("atac",false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk",true);
        }
        else
        {
            anim.SetBool("walk",false);
        }
    }
}
