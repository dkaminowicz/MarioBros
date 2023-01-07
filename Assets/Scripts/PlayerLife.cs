using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private int numberOflife = 3;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    private int score = 0;
    private int ennemyScore = 100;

    private Rigidbody2D rb;
    private Animator anim;
    private int MovementState;
    private int fallingState = 3;

    [SerializeField] private float timeLeft = 120f;
    [SerializeField] private float warningTimeLeft = 30f;

    [SerializeField] private float jumpForceWhenEnnemyDie = 4f;
    private bool isDie = false;

    private AudioSource backgroundSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource killEnnemySoundEffect;
    private AudioSource backgroundRunningOutOfTimeSoundEffect;
    private bool isWarningSoundPlay = false;

    AudioSource[] allMyBackgroundAudioSources;

    private void Start()
    {
        allMyBackgroundAudioSources = GameObject.Find("BG Music").GetComponents<AudioSource>();
        backgroundSoundEffect = allMyBackgroundAudioSources[0];
        backgroundRunningOutOfTimeSoundEffect = allMyBackgroundAudioSources[1];
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            Die();
        }
        else
        {
            timeText.text = (timeLeft).ToString("0");
            if(timeLeft <= warningTimeLeft && !isWarningSoundPlay)
            {
                isWarningSoundPlay = true;
                backgroundSoundEffect.Pause();
                backgroundRunningOutOfTimeSoundEffect.Play();
            }
            else if (timeLeft > warningTimeLeft)
            {
                backgroundRunningOutOfTimeSoundEffect.Pause();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ennemy"))
        {
              MovementState = (int)GetComponent<PlayerMovement>().state;
              if(MovementState == fallingState)
              {
                  rb.velocity = new Vector2(rb.velocity.x, jumpForceWhenEnnemyDie);
                  UpdateUIScore();
                  killEnnemySoundEffect.Play();
                  Destroy(collision.gameObject);

              } else
              {
                  Die();
              }
        }

        if(collision.gameObject.CompareTag("PlantEnnemy"))
        {
              Die();
        }
    }

    private void Die()
    {
        if(!isDie)
        {
            isDie = true;
            UpdateUILife();
            backgroundSoundEffect.Pause();
            backgroundRunningOutOfTimeSoundEffect.Pause();
            deathSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
        }

    }

    private void RestartLevel()
    {

        if(numberOflife > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("Game Over Screen");
        }

    }

    private void UpdateUILife()
    {
        numberOflife--;
        lifeText.text = "Lifes: " + numberOflife;
    }

    private void UpdateUIScore()
    {
        score += ennemyScore;
        scoreText.text = "Score:" + score;
    }

}
