using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 25);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * Time.deltaTime);    
        
    }
}
