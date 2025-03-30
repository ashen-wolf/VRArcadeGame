using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Basketball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float minBounceVelo = 0.05f;
    public float bounceCoefficient = 0.6f;
    private Vector3 lastVelocity;
    public bool testmode = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (testmode)
            print("basketball Collision Occured");
        if (collision.impulse.magnitude > minBounceVelo)
        {
            rb.velocity = Vector3.Reflect(lastVelocity * bounceCoefficient, collision.contacts[0].normal);
            //rb.velocity = collision.impulse * bounceCoefficient;
            if(testmode)
                print("basketball bounce occured");
        }
    }
}
