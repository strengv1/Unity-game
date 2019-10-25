using UnityEngine;


// Bunnies just hop around randomly :)
public class BunnyMovement : MonoBehaviour
{
        // Public variables
    public Rigidbody rb;
    public float jumpStrength;

        //Private variables
    private float hopFrequency;

    private void Start()
    {
        hopFrequency = 5 + Random.Range(-2.0f, 2.0f);
    }
    void Update()
    {
        hopFrequency -= Time.deltaTime;
        if (hopFrequency < 0)
        {
            hopFrequency = 5 + Random.Range(-2.0f, 2.0f);                                       // Set the hopping frequency between 3 and 7 seconds.
            Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));    // Randomize the direction we want to hop.

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
    }
}
