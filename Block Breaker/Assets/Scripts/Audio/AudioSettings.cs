using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    const string MUSIC_KEY = "music";
    const string SOUND_KEY = "sound";

    const string MUSIC_SLIDER_KEY = "musicSlider";
    const string SOUND_SLIDER_KEY = "soundSlider";

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    [SerializeField] private Toggle _musicCheckBox;
    [SerializeField] private Toggle _soundCheckBox;

    [SerializeField] private AudioMixer _masterMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey(MUSIC_KEY)) 
        {
            SetMusic();
        }

        if (PlayerPrefs.HasKey(SOUND_KEY)) 
        {
            SetSound();
        }

    }

    public void SetMusic() 
    {
        //Debug.LogError(PlayerPrefs.GetInt(MUSIC_KEY));
        if (PlayerPrefs.GetInt(MUSIC_KEY) == 1)
        {
            _masterMixer.SetFloat("Music", PlayerPrefs.GetFloat(MUSIC_SLIDER_KEY));
            _musicCheckBox.isOn = true;
        }
        else
        {
            _masterMixer.SetFloat("Music", -80);
            _musicCheckBox.isOn = false;
        }
    }

    public void SetSound() 
    {
        if (PlayerPrefs.GetInt(SOUND_KEY) == 1)
        {
            _masterMixer.SetFloat("Sound", PlayerPrefs.GetFloat(SOUND_SLIDER_KEY));
            _soundCheckBox.isOn = true;
        }
        else
        {
            _masterMixer.SetFloat("Sound", -80);
            _soundCheckBox.isOn = false;
        }
    }

    public void TuneMusic() 
    {
        if (_musicSlider.value != PlayerPrefs.GetFloat(MUSIC_SLIDER_KEY)) 
        {
            PlayerPrefs.SetFloat(MUSIC_SLIDER_KEY, _musicSlider.value);
            _masterMixer.SetFloat("Music", _musicSlider.value);
        }
    }

    public void TuneSound() 
    {
        if (_soundSlider.value != PlayerPrefs.GetFloat(SOUND_SLIDER_KEY))
        {
            PlayerPrefs.SetFloat(SOUND_SLIDER_KEY, _soundSlider.value);
            _masterMixer.SetFloat("Sound", _soundSlider.value);
        }
    }

    public void TurnOn_OffMusic() 
    {
        int temp = PlayerPrefs.GetInt(MUSIC_KEY);

        if (temp == 1 || !PlayerPrefs.HasKey(MUSIC_KEY))
        {
            PlayerPrefs.SetInt(MUSIC_KEY, 0);
            _masterMixer.SetFloat("Music", -80);
        }
        else if (temp == 0)
        {
            PlayerPrefs.SetInt(MUSIC_KEY, 1);
            _masterMixer.SetFloat("Music", 0);
        }
        
    }

    public void TurnOn_OffSound()
    {
        int temp = PlayerPrefs.GetInt(SOUND_KEY);

        if (temp == 1 || !PlayerPrefs.HasKey(SOUND_KEY))
        {
            PlayerPrefs.SetInt(SOUND_KEY, 0);
            _masterMixer.SetFloat("Sound", -80);
        }
        else if (temp == 0)
        {
            PlayerPrefs.SetInt(SOUND_KEY, 1);
            _masterMixer.SetFloat("Sound", 0);
        }
    }
}
