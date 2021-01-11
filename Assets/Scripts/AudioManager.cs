using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private void Start()
    {
        // Starts the music;
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
       
    }
}
