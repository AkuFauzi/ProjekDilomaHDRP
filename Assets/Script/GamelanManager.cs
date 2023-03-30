using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamelanManager : MonoBehaviour
{
    public static GamelanManager instance;
    public AudioClip[] gamelanSFX;

    

    public AudioSource gamelanAudioSource;
    // Start is called before the first frame update
    public void PlayGamelan(int gamelanButton)
    {
        if (gamelanButton == 1)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[1]);
        }
        if (gamelanButton == 2)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[2]);
        }
        if (gamelanButton == 3)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[3]);
        }
        if (gamelanButton == 4)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[4]);
        }
        if (gamelanButton == 5)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[5]);
        }
        if (gamelanButton == 6)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[6]);
        }
        if (gamelanButton == 7)
        {
            gamelanAudioSource.PlayOneShot(gamelanSFX[7]);
        }
    }
}
