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
	rbd = GetComponent<Rigidbody>();
	player_script = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
    
    void Update () {
	rbd.AddForce(0, 0, speed, ForceMode.Impulse);

	if (player_script.bonus_in_use) {
	    TurnToBonus(4f);
	} else {
	    TurnToEnemy();
	    // Change this to a texture or something that makes more sense
	    GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
	}
    }

    public void TurnToBonus(float seconds) {
	rbd.useGravity = false;
        isEnemy = false;
        myCollider.enabled = false;
	// Change this to a texture or something that makes more sense
	GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
    }

    void TurnToEnemy() {
        isEnemy = true;
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (player_script.bonus_in_use)
		other.GetComponent<PlayerScore>().GetBonus();
            else 
		other.GetComponent<PlayerHealth>().TakeHit();

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
