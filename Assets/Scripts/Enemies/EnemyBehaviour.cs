using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool isEnemy;
    public Collider myCollider;
    public float speed = 2;

    Rigidbody rbd;

    GameObject Player;
    PlayerControl player_script;
    
    void Start() {
        isEnemy = true;        
        // bonusTimer = 0;
	rbd = GetComponent<Rigidbody>();
	player_script = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
    
    void Update () {
	rbd.AddForce(0, 0, speed, ForceMode.Impulse);

	if (player_script.bonus_in_use){
	    TurnToBonus(4f);
	} else {
	    TurnToEnemy();
	    GetComponent<Renderer>().material.SetColor("_Color", Color.red);
	}
    }

    public void TurnToBonus(float seconds) {
	rbd.useGravity = false;
        isEnemy = false;
        myCollider.enabled = false;
        // bonusTimer = seconds;
	GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    void TurnToEnemy() {
        isEnemy = true;
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (isEnemy)
                other.GetComponent<PlayerHealth>().TakeHit();
            else
                other.GetComponent<PlayerScore>().GetBonus();

            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
        void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == ("Kill")) 
            Destroy(gameObject);
	}
}
