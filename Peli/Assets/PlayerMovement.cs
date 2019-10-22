using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float movementSpeed = 1f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetKey("w") )
        {
            transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
        }
        if ( Input.GetKey("a") )
        {
            transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
        } 
    }
}
