using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour {
    public int score;
<<<<<<< HEAD
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
=======
    public GameObject score_output;
    TextMeshProUGUI text_score;
>>>>>>> 7202b6d54c2361a17460f6468e38a3583ef6231a

    void Start(){
	text_score = score_output.GetComponent<TextMeshProUGUI>();
	text_score.text = "Score: " + score;
    }
    
    public void GetBonus() {
        score += Mathf.RoundToInt(score * 0.1f);
	score ++;

	text_score.text = "Score: " + score;
    }
}
