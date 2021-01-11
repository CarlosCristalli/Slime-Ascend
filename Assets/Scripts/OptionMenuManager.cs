using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenuManager : MonoBehaviour
{
    public Slider Music;
    public Slider Effects;
    public Slider Sensitivity;

    public Image MusicMute;
    public Image EffectsMute;

    public AudioMixer MusicMixer;
    public AudioMixer EffectsMixer;

    float MusicVolume = 10;
    float EffectsVolume = 10;

    public float SensitivityValue = 0.2f;

    //bool isMusicMuted;
    //bool isEffectsMuted;

    private void Start()
    {
        //Gets Sensitivity value or sets as default value of 0.2f
        PlayerPrefs.GetFloat("Sensitivity", SensitivityValue);
        //Gets MusicVolume value or sets as default value of 10
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", MusicVolume);
        //Gets EffectsVolume value or sets as default value of 10
        EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume", EffectsVolume);

        //Sets the Music and efects value as saved in the PlayerPref
        Music.value = PlayerPrefs.GetFloat("MusicVolume", MusicVolume);
        Effects.value = PlayerPrefs.GetFloat("EffectsVolume", MusicVolume);
        Sensitivity.value = PlayerPrefs.GetFloat("Sensitivity", SensitivityValue);

        //Saves the The music and the SFX value
        MusicMixer.SetFloat("MusicVolume", MusicVolume);
        MusicMixer.SetFloat("SFXVolume", EffectsVolume);

        //if the music or the effects value drops near the end values show the mute image so the player can see is muted
        if (MusicVolume < -79)
        {
            MusicMute.gameObject.SetActive(true);
        }
        if (EffectsVolume < -79)
        {
            EffectsMute.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
    public void MuteMusic()
    {
        //If called makes the music stop and saves voluem as -80
        if (MusicMute.gameObject.activeInHierarchy)
        {
            MusicMixer.SetFloat("MusicVolume", MusicVolume);
            MusicMute.gameObject.SetActive(false);
        }
        else
        {
            MusicMixer.GetFloat("MusicVolume", out MusicVolume);
            MusicMixer.SetFloat("MusicVolume", -80f);
           
            MusicMute.gameObject.SetActive(true);
        }
        PlayerPrefs.SetFloat("MusicVolume", -80f);
    }

    public void MuteEffects()
    {
        //If called makes the effects impossible to hear and saves voluem as -80
        if (EffectsMute.gameObject.activeInHierarchy)
        {
            EffectsMixer.SetFloat("SFXVolume", EffectsVolume);
            EffectsMute.gameObject.SetActive(false);
        }
        else
        {
            EffectsMixer.GetFloat("SFXVolume", out EffectsVolume);
            EffectsMixer.SetFloat("SFXVolume", -80f);
            
            EffectsMute.gameObject.SetActive(true);
        }
        PlayerPrefs.SetFloat("EffectsVolume", -80f);
    }
    //Changes  and saves the value of the Sensitivity based on the UI slider
    public void  ChangeSensitivity()
    {
        PlayerPrefs.SetFloat("Sensitivity", Sensitivity.value);

        SensitivityValue = Sensitivity.value;
    }
    //Changes  and saves the value of the Music sound based on the UI slider
    public void MusicChangeVolume()
    {
        MusicVolume = Music.value;
        MusicMixer.SetFloat("MusicVolume", Music.value);
        MusicMute.gameObject.SetActive(false);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        if (MusicVolume < -79)
        {
            MusicMute.gameObject.SetActive(true);
        }
        
    }
    //Changes  and saves the value of the Effects sound based on the UI slider
    public void EffectsChangeVolume()
    {
        EffectsVolume = Effects.value;
        EffectsMixer.SetFloat("SFXVolume", Effects.value);
        EffectsMute.gameObject.SetActive(false);
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolume);
        
        if (EffectsVolume < -79)
        {
            EffectsMute.gameObject.SetActive(true);
        }
    }
}
