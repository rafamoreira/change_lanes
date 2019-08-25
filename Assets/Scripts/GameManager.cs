using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool gameOver;
    float gameCountdown;

    public AudioClip sfx;
    AudioSource sfxFont;
    void Start()
    {
        gameStarted = false;
        gameOver = false;
        gameCountdown = 3;
        Time.timeScale = 0;
        sfxFont = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameOver)
        {
            if (gameCountdown > 0)
            {
                gameCountdown -= Time.unscaledDeltaTime;
            }

            if (gameCountdown <= 0)
            {
                StartLevelRoutine();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Rubens", LoadSceneMode.Single);
            }
        }
    }

    public void GameOver()
    {
        sfxFont.PlayOneShot(sfx);
        gameOver = true;
        gameStarted = false;
        Time.timeScale = 0;
    }

    void StartLevelRoutine()
    {
        Time.timeScale = 1;
        gameOver = false;
        gameStarted = true;
    }
}


