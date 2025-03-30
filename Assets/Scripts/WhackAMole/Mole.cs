using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    // Start is called before the first frame update
    public WhackAMoleScoreManager scoreManager;

    int score = 5;

    public Transform mole;
    public CapsuleCollider moleCollider;

    public Countdown timer;

    public float exposeTime = 3f;
    public float exposeHeight = 0.1f;
    public float exposeLikelihood = 5f;
    public float exposelikelihoodRamping = 0.025f;

    private bool exposed = false;
    private IEnumerator coroutine;
    private Vector3 startPosition;
    private void Awake()
    {
        mole = transform.GetChild(0);
        moleCollider = mole.GetComponent<CapsuleCollider>();    
        startPosition = transform.position;
    }
    private void OnEnable()
    {
        timer.updateCallback += timerUpdate;
        timer.timerComplete += hide;
    }
    private void OnDisable()
    {
        timer.updateCallback -= timerUpdate;
        timer.timerComplete -= hide;
    }
    void Start()
    { 

    }

    public void Hit()
    {
        scoreManager.addScore(score);
        hide();

    }
    private void expose()
    {
        exposed = true;
        moleCollider.enabled = true;
        mole.position = new Vector3(startPosition.x, startPosition.y + exposeHeight, startPosition.z);
        coroutine = exposeTimer();
        StartCoroutine(coroutine);
    }
    private void hide()
    {
        exposed = false;
        moleCollider.enabled = false;
        mole.position = startPosition;
    }
    private void timerUpdate(int secondsRemaining)
    {
        if (exposed)
            return;
        if(1f > Random.Range(0, exposeLikelihood - ((timer.time - secondsRemaining) * exposelikelihoodRamping)))
        {
            expose();
        }
    }
    private IEnumerator exposeTimer()
    {
        yield return new WaitForSeconds(exposeTime);
        hide();
    }
 
}
