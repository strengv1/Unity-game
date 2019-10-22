using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 500f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetKey("w") )
        {            
            rb.AddForce(0, 0, speed * Time.deltaTime);
        } 
        else if ( Input.GetKey("a") )
        {            
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
}
