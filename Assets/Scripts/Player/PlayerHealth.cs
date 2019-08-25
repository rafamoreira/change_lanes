using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts;

    void Start() {
	isAlive = true;
	hearts = 3;
    }

    public void TakeHit() {
        hearts--; 

        if (hearts <= 0) {
           GameManager.Instance.GameOver();
	   isAlive = false;
        }
    }
}
