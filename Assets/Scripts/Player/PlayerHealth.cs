using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts;
    public int initialHearts; 

    void Start()
    {
        hearts = initialHearts;
    }

    public void TakeHit()
    {
        Debug.Log("hit");
        hearts -= 1; 

        if (hearts <= 0)
        {
           GameManager.Instance.GameOver(); 
        }

    }

}
