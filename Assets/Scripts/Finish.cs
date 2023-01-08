using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSoundEffect;
    AudioSource[] allMyBackgroundAudioSources;
    private AudioSource backgroundSoundEffect;
    private AudioSource backgroundRunningOutOfTimeSoundEffect;

    [HideInInspector] public bool levelCompleted = false;

    private void Start() {
        allMyBackgroundAudioSources = GameObject.Find("BG Music").GetComponents<AudioSource>();
        backgroundSoundEffect = allMyBackgroundAudioSources[0];
        backgroundRunningOutOfTimeSoundEffect = allMyBackgroundAudioSources[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            backgroundSoundEffect.Pause();
            backgroundRunningOutOfTimeSoundEffect.Pause();
            finishSoundEffect.Play();
            Invoke("CompleteLevel", 6f);

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
