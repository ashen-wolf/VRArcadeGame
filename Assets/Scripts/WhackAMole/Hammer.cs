using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool swinging = false;
    public float swingVelocity = 0.005f;
    private Vector3 currVelocity;
    Vector3 previousLocation;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        currVelocity = transform.position - previousLocation;
        previousLocation = transform.position;
        swinging = currVelocity.y > swingVelocity;
        //print("swinging: " + swinging.ToString());
    }
}
