using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int hearts;
    public GameObject heart_output;
    TextMeshProUGUI text_hearts;

    void Start() {
	text_hearts = heart_output.GetComponent<TextMeshProUGUI>();
	hearts = 3;
	text_hearts.text = "Life: " + hearts;
    }

    public void TakeHit() {
        hearts--; 
        if (hearts <= 0) {
           GameManager.Instance.GameOver();
        }
	text_hearts.text = "Life: " + hearts;
    }
}
