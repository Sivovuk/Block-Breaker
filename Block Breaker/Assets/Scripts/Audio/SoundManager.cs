using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public AudioSource bounce;
    public AudioSource click1;
    public AudioSource click2;
    public AudioSource click3;
    public AudioSource clunk;

    private static SoundManager instance;

    public static SoundManager Instance => instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioSource audio) 
    {
        if (audio != null) 
        {
            audio.PlayOneShot(audio.clip);
        }
    }

    public void StopAudio(AudioSource audio)
    {
        if (audio != null)
        {
            audio.Stop();
        }
    }
}
