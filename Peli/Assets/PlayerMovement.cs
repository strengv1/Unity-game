using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class playerMovement : MonoBehaviour
{
    public Animator foxAnim;
    public LayerMask movementMask;
    public Rigidbody rb;
    public float jumpPower;
    Camera cam;
    NavMeshAgent agent;

    void Start()
    {
        foxAnim = GetComponentInChildren<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jump!
        if ( Input.GetKeyDown( KeyCode.Space )) {
            jump();
        }
        // Read the location of the mouse when clicking on "ground" and move the foxy there.
        if ( Input.GetMouseButtonDown(0) )
        {               
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, 100, movementMask)) // ray, "out hit", range?, mask
            {
                MoveToPoint(hit.point);
            }
        }
   
        // Change the "walking" parameter, which controls what animation we play.
        if( agent.hasPath ) {
            foxAnim.SetBool("walking", true);
        } else { 
            foxAnim.SetBool("walking", false);
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void jump()
    {
        Debug.Log("jump");
        rb.AddForce(0f, jumpPower, 0f);
    }
}
