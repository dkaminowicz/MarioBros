using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSoundEffect;
    private AudioSource backgroundSoundEffect;

    private bool levelCompleted = false;

    private void Start() {
        backgroundSoundEffect = GameObject.Find("BG Music").GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            backgroundSoundEffect.Pause();
            finishSoundEffect.Play();
            Invoke("CompleteLevel", 6f);

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
