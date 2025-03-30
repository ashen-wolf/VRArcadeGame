using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Mole mole;
    void Start()
    {
        mole = transform.parent.GetComponent<Mole>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Hammer hammer;
        print("Collision with mole");
        if (hammer = collision.gameObject.GetComponent<Hammer>())
        {
            print("hammer hit mole");
            //if (hammer.swinging) unfortunately this is frustratingly inconsistent
                mole.Hit();
        }
    }
}
