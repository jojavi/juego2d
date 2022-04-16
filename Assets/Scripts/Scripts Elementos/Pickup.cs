using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] private float scoreForPickup = 100f;
    [SerializeField] AudioClip audioClip;
    private bool wasActivated = false;
  
    
   private void OnTriggerEnter2D(Collider2D other) {
       
        //Debug.Log(" debug ");

        if (wasActivated) { return; }
        if (!other.CompareTag("Player")) { return; }
        if (!other.TryGetComponent<Score>(out Score score)) { return; }

        wasActivated = true;
        score.AddScore(scoreForPickup);
        PlaySound();
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        Destroy(gameObject, audioClip.length);



    }

      private void PlaySound()
    {

        if (audioClip == null) { return; }
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);

    }

}
