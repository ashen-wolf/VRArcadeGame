using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BasketballScoreManager : GenericSingleton<BasketballScoreManager>
{
    // Start is called before the first frame update
    int score = 0;
    int highScore = 0;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public bool testMode;
    public Countdown timer;
    private int remainingTime;
    private bool gaming = false;
    void OnEnable()
    {
        timer.updateCallback += timerChanged;
        timer.timerComplete += endGame;
    }
    private void OnDisable()
    {
        timer.updateCallback -= timerChanged;
        timer.timerComplete -= endGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newGame()
    {
        if (highScore < score)
            highScore = score;
        gaming = true;
        score = 0;
        timer.StartTimer();
        ScoreChanged();

    }
    public void resetScore()
    {
        highScore = 0;
        score = 0;
        ScoreChanged();
    }
    public void addScore(int newScore)
    {
        if (gaming)
        {
            print("Basketball Score added");
            score += newScore;
            ScoreChanged();
        }
    }
    private void ScoreChanged()
    {
        print("Basketball Score Changed");
        scoreText.text = "Score: " + score.ToString() + "\nHighscore: " + highScore.ToString();
        
    }
    private void timerChanged(int time)
    {
        remainingTime = time;
        timerText.text = "Time: " + remainingTime.ToString();
    }
    private void endGame()
    {
        gaming = false;
    }
}
