using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool isEnemy;
    public float bonusTimer;

    public Collider myCollider;
    void Start()
    {
        isEnemy = true;        
        bonusTimer = 0;
    }
    
    void Update ()
    {
        if (bonusTimer >= 0) 
        {
            bonusTimer -= Time.deltaTime;
        }
        else if (!isEnemy) 
        {
            TurnToEnemy();
        }
        if (Input.GetKeyDown("space"))
        {
            TurnToBonus(4f);
        }

    }

    public void TurnToBonus(float seconds)
    {
        isEnemy = false;
        myCollider.enabled = false;
        bonusTimer = seconds;
    }

    void TurnToEnemy()
    {
        isEnemy = true;
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isEnemy)
            {
                other.GetComponent<PlayerHealth>().TakeHit();
            }
            else
            {
                other.GetComponent<PlayerScore>().GetBonus();
            }

            Die();

        }
    }

    private void Die() 
    {
        Destroy(gameObject);
    }
}
