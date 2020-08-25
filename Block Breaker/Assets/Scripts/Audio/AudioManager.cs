using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayClick1Sound()
    {
        SoundManager.Instance.PlayAudio(SoundManager.Instance.click1);
    }

    public void PlayClick2Sound() 
    {
        SoundManager.Instance.PlayAudio(SoundManager.Instance.click2);
    }


}
