using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour {
    public int score;
    public float timeToScore;
    public GameObject score_output;

    float timer;
    TextMeshProUGUI text_score;

    void Start()
    {
        timer = 0;
	text_score = score_output.GetComponent<TextMeshProUGUI>();
	text_score.text = "Score: " + score;
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
                timer -= Time.deltaTime;
            }
        }
    }
    
    public void GetBonus() {
        score += Mathf.RoundToInt(score * 0.1f);
	score ++;

	text_score.text = "Score: " + score;
    }
}
