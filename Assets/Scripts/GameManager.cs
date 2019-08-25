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

  public bool gameStarted;
  float gameCountdown;

  void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

  void Start(){  
    gameStarted = false;
    gameCountdown = 2f;
  }

  void Update()
  {
    if(gameCountdown > 0)
    {
      gameCountdown -= Time.deltaTime;
    }

    if(!gameStarted && gameCountdown <= 0)
    {
      StartLevelRoutine();
    }
  }

  public void GameOver()
  {
      Debug.Log("game over");
  }

  void StartLevelRoutine()
  {
      gameStarted = true;
  }
}


