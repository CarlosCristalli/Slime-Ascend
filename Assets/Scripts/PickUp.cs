using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Ref to the player
    BoostCollection Player;
    void Start()
    {
        //Finds the player
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoostCollection>(); 
    }
    //After beeing picked deactivates this gameObject but with time to end the script funcions
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.01f);
        this.gameObject.SetActive(false);
    }
    //Move towards the player and only when it reaches start fade
    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.01f);
        if(transform.position != Player.gameObject.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.gameObject.transform.position, (20 * Time.deltaTime));
            StartCoroutine("Move");
        }
        else
        {
            StartCoroutine("Fade");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If collides with the player start fading
        if (other.tag == "Player" )
        {
            //Debug.Log("PickUP");
            if (!Player.BoostOn || this.gameObject.tag == "Coin")
            {
                StartCoroutine("Fade");
            }
            
        }
        //if collides with the Magnet start moving towards the player
        if (other.tag == "Magnet")
        {
            if (!Player.BoostOn || this.gameObject.tag == "Coin")
            {
                Debug.Log("Translate");
                StartCoroutine("Move");
            }
        }
    }
}
