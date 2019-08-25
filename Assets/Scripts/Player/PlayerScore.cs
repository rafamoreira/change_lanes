using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour {
    public int score;
    public GameObject score_output;
    TextMeshProUGUI text_score;

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
