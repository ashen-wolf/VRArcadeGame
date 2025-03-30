using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BasketballHole : MonoBehaviour
{
    // Start is called before the first frame update
    private SphereCollider hole;
    public int score;

    void Start()
    {
        hole = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        print("Something collided with basketball hole");
        if (collider.transform.CompareTag("Basketball"))
        {
            print("basketball collided with basketball hole");
            BasketballScoreManager.Instance.addScore(score);
        }
    }
}