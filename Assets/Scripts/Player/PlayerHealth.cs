using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int hearts;
    public GameObject heart_output;
    TextMeshProUGUI text_hearts;

    PlayerControl pControl;
    [SerializeField] GameObject gameOverScreen;
    public AudioClip sfx;
    AudioSource sfxFont;

  void Start()
  {
        sfxFont = GetComponent<AudioSource>();

        gameOverScreen.SetActive(false);
        text_hearts = heart_output.GetComponent<TextMeshProUGUI>();
    hearts = 3;
    text_hearts.text = "Life: " + hearts;
    pControl = GetComponent<PlayerControl>();
  }

  void Update()
  {
    text_hearts.text = "Life: " + hearts;
  }

    public void TakeHit()
    {
        hearts--;

        if (hearts <= 0)
        {
            
            GameManager.Instance.GameOver();

            gameOverScreen.SetActive(true);
        }
        else
        {
            sfxFont.PlayOneShot(sfx, 1);
        }
        pControl.ResetBonusTimer();
  }
}
