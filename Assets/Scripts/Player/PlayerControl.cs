using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public Transform middleLane;
    public Transform leftLane;
    public Transform rightLane;
    public float bonusTimer;
    public float lateral_speed = 1.0F;
    public float lateral_distance = 50;
    public float speed_impulse = 10;
    public bool bonus_in_use = false;

    int current_lane;
    float startTime;
    Rigidbody rbd;


    float initial_set_bonus_timer;
    
    // Start is called before the first frame update
    void Start() {
        rbd = GetComponent<Rigidbody>();
	current_lane = 1;
	initial_set_bonus_timer = bonusTimer;
    }

    void Update(){
        if (bonusTimer <= 0){
	    bonus_in_use = false;
	} 

	// Movement
	if (current_lane >= 1 && Input.GetKeyDown(KeyCode.A)){
	    transform.Translate(-Vector3.forward * lateral_distance * Time.deltaTime);
	    current_lane--;
	    GetCurrentLane(current_lane);
	}
	if (current_lane <= 1 && Input.GetKeyDown(KeyCode.D)){
	    transform.Translate(-Vector3.forward * -lateral_distance * Time.deltaTime);
	    current_lane++;
	    GetCurrentLane(current_lane);
	}

	if (!bonus_in_use && Input.GetKeyDown("space")) {
	    bonusTimer = initial_set_bonus_timer;
	    bonus_in_use = true;
        }

	if (bonus_in_use){
	    bonusTimer -= Time.deltaTime;
	}
}

    
    void GetCurrentLane(int lane){
	if(lane == 0)
	    transform.position = new Vector3(leftLane.position.x, transform.position.y, transform.position.z);
	else if(lane == 1) 
	    transform.position = new Vector3(middleLane.position.x, transform.position.y, transform.position.z);
	else if (lane == 2)
	    transform.position = new Vector3(rightLane.position.x, transform.position.y, transform.position.z);
    }
}
