using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
  public Transform middleLane;
  public Transform leftLane;
  public Transform rightLane;
  public float bonusTimer;
  public float lateral_speed = 1.0F;
  public float lateral_distance = 50;
  public float speed_impulse = 10;
  public bool bonus_in_use = false;
  public float timeSinceBonus;
  public bool bonusAllowed;

  int current_lane;
  float startTime;
  Rigidbody rbd;

  float initial_set_bonus_timer;

  public TextMeshProUGUI text_bonus;


  // Start is called before the first frame update
  void Start()
  {
    rbd = GetComponent<Rigidbody>();
    current_lane = 1;
    initial_set_bonus_timer = bonusTimer;
    timeSinceBonus = 0;
  }

  void Update()
  {
    timeSinceBonus += Time.deltaTime;

    if (bonus_in_use)
    {
      bonusTimer -= Time.deltaTime;
			text_bonus.text = "BONUS TIME!!!!\n" + System.Math.Round(bonusTimer, 2);
    }

    if (timeSinceBonus >= 10)
    {
      bonusAllowed = true;
			text_bonus.text = "SPACE TIME!!!!";
    }
    else
    {
      bonusAllowed = false;
			
			if (!bonus_in_use)
				text_bonus.text = "TIME TO BONUS\n" + System.Math.Round((10 - timeSinceBonus), 2);
    }

    if (bonusTimer <= 0)
    {
      bonus_in_use = false;
    }

    if (bonusAllowed && !bonus_in_use && Input.GetKeyDown("space"))
    {
      bonusTimer = initial_set_bonus_timer;
      bonus_in_use = true;
      bonusAllowed = false;
      timeSinceBonus = 0;
      bonusTimer = 5;
    }

    if (GameManager.Instance.gameStarted)
    {
      // Movement
      if (current_lane >= 1 && Input.GetKeyDown(KeyCode.A))
      {
        transform.Translate(-Vector3.forward * lateral_distance * Time.deltaTime);
        current_lane--;
        GetCurrentLane(current_lane);
      }
      if (current_lane <= 1 && Input.GetKeyDown(KeyCode.D))
      {
        transform.Translate(-Vector3.forward * -lateral_distance * Time.deltaTime);
        current_lane++;
        GetCurrentLane(current_lane);
      }
    }
  }


  void GetCurrentLane(int lane)
  {
    if (lane == 0)
      transform.position = new Vector3(leftLane.position.x, transform.position.y, transform.position.z);
    else if (lane == 1)
      transform.position = new Vector3(middleLane.position.x, transform.position.y, transform.position.z);
    else if (lane == 2)
      transform.position = new Vector3(rightLane.position.x, transform.position.y, transform.position.z);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("point");
    }
  }

  public void ResetBonusTimer()
  {
		timeSinceBonus = 0;
  }
}


