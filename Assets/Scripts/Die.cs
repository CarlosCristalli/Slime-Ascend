using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    //Script to handle the player Death
    //Camera info
    FollowPlayerPosition camera;
    //EndScreen canvas GameObject
    public GameObject EndScreen;
    //Score display GameObject durring the game
    public GameObject Score;
    //High score reference
    public Dice EndScore;
    //Get boostInfo to check if it is in the Unkillable
    BoostCollection Boosts;
    
    void Awake()
    {
        //assing the var
        EndScore.GetComponent<Dice>();
        EndScreen = GameObject.FindGameObjectWithTag("EndScreen");
        Score = GameObject.FindGameObjectWithTag("Score");
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent< FollowPlayerPosition>();
        Boosts = GetComponent<BoostCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        //Death by dropping of the map
        if(transform.position.y < (camera.Maxhight - 25f))
        {
           //Deactivats the player gameObject and the score display and also activates the Endgame Screen
            gameObject.SetActive(false);
            EndScreen.SetActive(true);
            Score.SetActive(false);
            //Compere the score with the high score
            EndScore.RollDice();
        }
    }
    //Deth by Mob
    public void KillPlayer()
    {
        //if is killable by mobs
        if (Boosts.Killable)
        {
            //Deactivats the player gameObject and the score display and also activates the Endgame Screen
            gameObject.SetActive(false);
            EndScreen.SetActive(true);
            Score.SetActive(false);
            //Compere the score with the high score
            EndScore.RollDice();
        }
        
    }
}
