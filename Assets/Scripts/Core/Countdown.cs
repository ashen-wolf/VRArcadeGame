using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int time = 30;
    public int timeRemaining = 0;
    public delegate void UpdateCallback(int timeRemaining);
    public UpdateCallback updateCallback;
    public delegate void TimerComplete();
    public TimerComplete timerComplete;
    public float secondLength = 1.0f;
    private IEnumerator coroutine;

    public void StartTimer()
    {
        timeRemaining = time;
        if(coroutine != null ) 
            StopCoroutine(coroutine);
        coroutine = Timer(secondLength);
        StartCoroutine(coroutine);
    }
    private IEnumerator Timer(float waitTime)
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(waitTime);

            timeRemaining--;
            updateCallback?.Invoke(timeRemaining);
            StartCoroutine(coroutine);
        }
        timerComplete?.Invoke();
    }
}