using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBasketball : VRButton
{
    // Start is called before the first frame update
    public List<Basketball> balls;
    public Transform ballSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void Pressed()
    {
        base.Pressed();
        int i = 0;
        foreach (var basketball in balls)
        {
            basketball.transform.position = ballSpawn.position + new Vector3(0,0,i/2);
            i++;
        }
        BasketballScoreManager.Instance.newGame();
    }
}
