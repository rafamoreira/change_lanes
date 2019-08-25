using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {
    public int score;
    public float timeToScore;
    float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    { 
        if(GameManager.Instance.gameStarted) 
        {
            if (timer <= 0){
                score += 1;
                timer = timeToScore;
            }
            else
            {
                timer = Time.deltaTime;
            }
        }
    }

    public void GetBonus() {
        score += Mathf.RoundToInt(score * 0.1f);
    }
}
