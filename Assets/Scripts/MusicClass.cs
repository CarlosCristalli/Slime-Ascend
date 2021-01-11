using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        //Makes sure the music dont stop when changing scenes 
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        //If the music is playing do nothing if is not start the music
        if (_audioSource.isPlaying)
        {
            return;
        }
        else
        {
            _audioSource.Play();
        }
        
    }
    //Stops the music
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
