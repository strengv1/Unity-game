using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class playerMovement : MonoBehaviour
{
    public Animator foxAnim;
    public LayerMask movementMask;
    Camera cam;
    NavMeshAgent agent;

    void Start()
    {
        foxAnim = GetComponentInChildren<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {               
            foxAnim.SetBool("walking", true);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, 100, movementMask)) // ray, "out hit", range?, mask
            {
                MoveToPoint(hit.point);
            }
        }
        
        if(!agent.hasPath)
        {
            foxAnim.SetBool("walking", false);
        }

    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);

    }
}
