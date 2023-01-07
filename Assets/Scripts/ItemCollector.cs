using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ItemCollector : MonoBehaviour
{

    private int numberOfCoins = 0;

    [SerializeField] private Text coinText;

    [SerializeField] private AudioSource coinSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CollectibleItem")) {
              coinSoundEffect.Play();
              Destroy(collision.gameObject);
              numberOfCoins++;
              coinText.text = "Coins: " + numberOfCoins;
        }

    }


}
