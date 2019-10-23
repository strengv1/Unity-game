using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, 100, movementMask)) // ray, "out hit", range?, mask
            {
                Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                // Move our player to what we hit

                //Stop focusing 
            }
        }
    }
}
