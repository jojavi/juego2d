using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavelExit : MonoBehaviour
{
   [SerializeField] AudioClip audioClip;

    private bool wasActivated = false;



    private void OnCollisionEnter2D(Collision2D other)

    {

        if (wasActivated) { return; }

        if (!other.gameObject.CompareTag("Player")) { return; }



        wasActivated = true;

        PlaySound();

        LoadNextLevel();

    }
       private void LoadNextLevel()

    {

        int currentIndex = SceneManager.GetActiveScene().buildIndex;



        if (currentIndex + 1 >= SceneManager.sceneCountInBuildSettings)

        {

            SceneManager.LoadScene(0);

        }

        else

        {

            SceneManager.LoadScene(currentIndex + 1);

        }

    }



    private void PlaySound()

    {

        if (audioClip == null) { return; }



        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(audioClip);

    }


}
