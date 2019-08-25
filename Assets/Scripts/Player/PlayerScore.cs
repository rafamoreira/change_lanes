using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;

    void Start()
    {
        score = 10;
    }

    public void GetBonus()
    {
        score += Mathf.RoundToInt(score * 0.1f);
    }
}
