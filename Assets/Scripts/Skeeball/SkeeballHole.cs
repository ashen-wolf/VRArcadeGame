using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeeballHole : MonoBehaviour
{
    // Start is called before the first frame update
    private SphereCollider hole;
    private int score;

    void Start()
    {
        hole = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Skeeball"))
        {
            SkeeballScore.Instance.addScore(score);
            Destroy(collision.transform.gameObject);
        }
    }
}
