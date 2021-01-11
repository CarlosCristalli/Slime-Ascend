using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollection : MonoBehaviour
{
    //Ref to the moviment infoOfThePlayer
    PlayerMoviment Player;
    // Way to store the original jump force to it can be altered by the jump Boost
    float originalJumpForce;
    // All Boosts must have fade time but it can be altered by upgrading them in the shop
    public float fadeTime = 0;
    // Show the player a Boost is active
    public SpriteRenderer BoostGlow;
    // Game object that simulates the Magnet efect by spreading the player collider (only for coins)
    public GameObject Magnet;


    public bool BoostOn = false;
    // if shield or the super jump are active the player should be able to die
    public bool Killable = true;

    //Boost fadeTime
    public float ShildBoostUpgrade = 5;
    public float JumpBoostUpgrade = 2;
    public float MagnetBoostUpgrade = 5;
    public float TimeBoostUpgrade = 1;
    
    void Start()
    {
        //Find player and jumpForce and specials fadeTime
        Player = GetComponent<PlayerMoviment>();
        originalJumpForce = Player.jumpForce;
        TimeBoostUpgrade = PlayerPrefs.GetFloat("TimeFadeTime", 1);
    }
    //Deactivate boost after FadeTime
   IEnumerator BoostFade()
    {
        yield return new WaitForSeconds(fadeTime);
        JumpBoostReverse();
        MagnetReverse();
        ShildReverse();
    }
    // When the player colides with a boost 
    void OnTriggerExit2D(Collider2D other)
    {

        //If there is no Boost on find out witch Boost the player has collided and activate the Boost
        if (!BoostOn)
        {
            if (other.tag == "JumpBoost")
            {
                JumpBoostUpgrade = PlayerPrefs.GetFloat("JumpMultiplyer", 2);
                JumpBoost();
            }
            if (other.tag == "MagnetBoost")
            {
                MagnetBoostUpgrade = PlayerPrefs.GetFloat("MagnetFadeTime", 5);
                MagnetBoost();
            }
            if (other.tag == "ShildBoost")
            {
                ShildBoostUpgrade = PlayerPrefs.GetFloat("ShildFadeTime", 5);
                ShildBoost();
            }
        }
        
    }

    void JumpBoost()
    {
        //Increace player jump
        Player.jumpForce = originalJumpForce * JumpBoostUpgrade;
        //Sets fadeTime
        fadeTime = 2;
        //Starts fadeTime countDown
        StartCoroutine("BoostFade");
        //Activate Boost visual indicator with the correct color
        BoostGlow.gameObject.SetActive(true);
        BoostGlow.color = Color.yellow;
        //Cant be Killed While Boost on
        Killable = false;
        BoostOn = true;
    }
    void MagnetBoost()
    {
        //Activate the GameObject with large Collider
        Magnet.SetActive(true);
        //Sets fadeTime
        fadeTime = MagnetBoostUpgrade + 2;
        //Starts fadeTime countDown
        StartCoroutine("BoostFade");
        //Activate Boost visual indicator with the correct color
        BoostGlow.gameObject.SetActive(true);
        BoostGlow.color = Color.blue;
        BoostOn = true;
    }
    void ShildBoost()
    {
        //Makes the player unkillable by mobs
        Killable = false;
        //Sets fadeTime
        fadeTime = ShildBoostUpgrade + 2;
        //Starts fadeTime countDown
        StartCoroutine("BoostFade");
        //Activate Boost visual indicator with the correct color
        BoostGlow.gameObject.SetActive(true);
        BoostGlow.color = Color.red;
        BoostOn = true;
    }
    void JumpBoostReverse()
    {
        //Resets JumpForce to original value
        Player.jumpForce = originalJumpForce;
        //Makes the player Killable again
        Killable = true;
        //Deactivate visual Boost indicator
        BoostGlow.gameObject.SetActive(false);
        BoostOn = false;
    }
    void MagnetReverse()
    {
        //Deactivates the gameObject with large Collider
        Magnet.SetActive(false);
        //Deactivate visual Boost indicator
        BoostGlow.gameObject.SetActive(false);
        BoostOn = false;
    }
    void ShildReverse()
    {
        //Makes the player Killable again
        Killable = true;
        //Deactivate visual Boost indicator
        BoostGlow.gameObject.SetActive(false);
        BoostOn = false;
    }

}
