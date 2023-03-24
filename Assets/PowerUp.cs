using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        rotationVector = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += rotationVector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "unitychan")
        {
            Destroy(this.gameObject);
        }
    }
}
