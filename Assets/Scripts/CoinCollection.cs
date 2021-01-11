using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    // Values for the total coins and the coins got durring this current match
    public int numOfCoinsTotal = 0;
    public int numOfCoinMach = 0;
    // The UI Object to disply the two values
    public Text CoinsOfMach;
    public Text TotalCoins;
    
    void Awake()
    {
        //Locate the UI Object using their tags
        CoinsOfMach = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        TotalCoins  = GameObject.FindGameObjectWithTag("TotalCoins").GetComponent<Text>();
        
    }

    void Start()
    {
    // Get totalCoins value stored in the PlayerPrefts but sets it as zero if there is none saved
        numOfCoinsTotal = PlayerPrefs.GetInt("Coin",0);
    //Presents the totalCoins value on the UI element
        TotalCoins.text = numOfCoinsTotal.ToString();
    }

    
    void Update()
    {
        // Adjusts the string if the number of Coins gets higher than one thousand
        if (numOfCoinsTotal > 1000)
        {
            TotalCoins.text = (numOfCoinsTotal/1000).ToString() + "k";
        }
        // if is not just write the number normaly
        else
        {
            TotalCoins.text = numOfCoinsTotal.ToString();
        }
        //write the num of coins that has been colected in this match in the respective UI
        CoinsOfMach.text = "Coins: " + numOfCoinMach.ToString();
    }

    // If the player Collides with a Coin Add a coin
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            numOfCoinMach++;
            numOfCoinsTotal = PlayerPrefs.GetInt("Coin") + 1;
            PlayerPrefs.SetInt("Coin", numOfCoinsTotal);
        }
    }
}
