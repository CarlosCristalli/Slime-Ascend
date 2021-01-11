using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    //Ref to the player
    GameObject player;
   
    void Start()
    {
        //Locate the player to assing the var
        player = GameObject.FindGameObjectWithTag("Player");
    }

   //Give comands to the player if the game is paused or gets resumed
    public void Resume()
    {
        player.GetComponent<PlayerMoviment>().Resume();
    }
    public void Pause()
    {
        player.GetComponent<PlayerMoviment>().Pause();
    }
}
