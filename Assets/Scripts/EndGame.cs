using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //Ref to give the player the coins
    CoinCollection Coins;

    
    void Awake()
    {
        //Finds the script in the player gameObject
        Coins = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinCollection>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player reaches the end of the game give the player 100 coins
        if (other.tag == "Player")
        {
            Coins.numOfCoinMach+= 100;
            //End the game by killing the player
            other.GetComponent<Die>().KillPlayer();
            
        }
    }

}
