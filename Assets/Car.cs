using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 50;
        movement = new Vector3(speed, 0, 0);

    }

    private void FixedUpdate()
    {
        if (transform.position.x > 10)
        {
            movement = new Vector3(-speed, 0, 0);
        }
        else if(transform.position.x < -10)
        {
            movement = new Vector3(speed, 0, 0);
        }
        rb.MovePosition(transform.position + movement * Time.deltaTime);    
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "unitychan")
        {
            var currentVelocity = rb.velocity;
            Debug.Log(currentVelocity);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(100, 20, 0);

            SceneManager.LoadScene("SampleScene");
        }
    }
}
