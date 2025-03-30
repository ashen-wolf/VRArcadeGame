using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHandle : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    Quaternion startRot;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetLocation()
    {
        transform.position = startPos;
        transform.rotation = startRot;  
    }
}
