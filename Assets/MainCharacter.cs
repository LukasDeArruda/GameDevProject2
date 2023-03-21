using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private bool countdown;
    private float timer;
    public Animator anim;
    private bool isOnGround;
    private Rigidbody playerRigidBody;
    private float speed;
    private float jumpHeight;
    private Vector3 movement;

    
    void Start()
    {
        countdown = false;
        timer = 0;
        playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.freezeRotation = true;
        speed = 5f;
        jumpHeight = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((movement.x != 0 || movement.z != 0) && isOnGround)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            countdown = true; 
        }

        if (countdown)
        {
            // timer stuff
            if (timer < 2)
            {
                timer += Time.deltaTime;
                //Debug.Log(timer);
            }
            else
            {
                //Application.Quit();
                //This is how we do it in the editor, above would be for complied game
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                anim.SetBool("isWalking", false);
                anim.SetTrigger("Jump");
                movement += new Vector3(0, jumpHeight, 0);
            }
        }
        playerRigidBody.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.name == "Ground")
        // {
        isOnGround = true;
        // }
    }

    private void OnCollisionExit(Collision collision)
    {
        // if (collision.gameObject.name == "Ground")
        // {
        isOnGround = false;
        // }
    }
}
