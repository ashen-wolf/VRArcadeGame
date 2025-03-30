using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballScore : GenericSingleton<SkeeballScore>
{
    // Start is called before the first frame update
    int score = 0;
    int highScore = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int newScore)
    {
        score += newScore;
    }

    public void resetScore()
    {
        if (score > highScore)
            highScore = score;
        score = 0;
    }
}
