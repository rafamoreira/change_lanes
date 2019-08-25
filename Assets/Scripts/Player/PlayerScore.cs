using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {
    public int score;

    public void GetBonus() {
	Debug.Log("POINT");
        score += Mathf.RoundToInt(score * 0.1f);
    }
}
