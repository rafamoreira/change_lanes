using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

  private static GameManager _instance;

  public static GameManager Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = GameObject.FindObjectOfType<GameManager>();
      }

      return _instance;
    }
  }
  public float TotalScore;

  public int enemyStatus;

  void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

  void Start()
  {
      enemyStatus = 0;
  }

  public void GameOver()
  {
      Debug.Log("game over");
  }

    public bool EnemyIsEnemy()
    {
        return enemyStatus == 0;
    }

    void FlipEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBehaviour>().TurnToBonus(5);
        }
    }
}


