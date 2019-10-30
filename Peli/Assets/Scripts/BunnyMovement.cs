using UnityEngine;
using UnityEngine.AI;

// Bunnies just hop around randomly :)
public class BunnyMovement : MonoBehaviour
{
        // Public variables
    public Rigidbody rb;
    public Collider collider;
    public float jumpStrength;
    public float frightenRange = 1;
    public NavMeshAgent threat;


        //Private variables
    private float hopFrequency;
    private bool frightened = false;
    private float frightenedDuration = 0f;
    private bool grounded = true;
    private float distToGround;
    private void Start()
    {
        distToGround = collider.bounds.extents.y;
        if ( !frightened )
        {
            hopFrequency = 5 + Random.Range(-2.0f, 2.0f);
        }
        else
        {
            hopFrequency = 1f;
        }
    }
    void Update()
    {
        Vector3 threatDir = (threat.transform.position - transform.position);
        if (threatDir.magnitude <= frightenRange)
        {
            frightened = true;
            hopFrequency = 0f;
            frightenedDuration = 3f;

        }
        else
        {
            if ( !(frightenedDuration <= 0) )
            {
                frightenedDuration -= Time.deltaTime;
            }
            if (frightenedDuration < 0)
            {
                frightened = false;
            }
            Debug.Log(frightenedDuration);
        }


        hopFrequency -= Time.deltaTime;
        if (hopFrequency < 0) {
                if ( !frightened ) {

                hopFrequency = 5 + Random.Range(-2.0f, 2.0f);                                       // Set the hopping frequency between 3 and 7 seconds.
                Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));    // Randomize the direction we want to hop.

                hop(dir);
            } else {
                Vector2 dir = new Vector2(-threatDir.x, -threatDir.z);
                dir.Normalize();
                if ( IsGrounded() ) { 
                    hop(dir*2);
                }
            }
        } 
    }

    void hop(Vector2 dir)
    {
        rb.AddForce(dir.x * jumpStrength / 1.5f, jumpStrength, dir.y * jumpStrength / 1.5f);

        float rot = (dir.x / dir.magnitude) * 180f / Mathf.PI;                              // Calculate the rotation from the directions

        if ((dir.x >= 0 && dir.y > 0) || (dir.x < 0 && dir.y >= 0))
        {
            transform.rotation = Quaternion.Euler(0f, rot, 0f);
        }
        else if ((dir.x <= 0 && dir.y < 0) || (dir.x > 0 && dir.y <= 0))
        {
            transform.rotation = Quaternion.Euler(0f, -rot + 180f, 0f);                     // I have no idea why this works but it does. Something about mirroring the vector on x axis, but +180?
        }
    }
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
 }
 


}
