using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    //Makes the camera follow the player

    //ref to the player
    public GameObject Player;
    //Player highest point reached
    public int Maxhight = 0;
    
    void Start()
    {
        //Locate player
        Player = GameObject.FindGameObjectWithTag("PlayerToCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // updates the highest position if the player surpasses it
        if (transform.position.y > Maxhight)
        {
            //sets the camera pos as the highest point reached
            Maxhight = (int)transform.position.y;
        }
        
        if (Player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y-0.5f, transform.position.z);
        }
    }
}
