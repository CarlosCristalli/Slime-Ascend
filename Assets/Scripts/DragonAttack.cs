using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    //ref to gradons animator
    Animator anim;
    // time between the fire attack
    public int coolDownTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        //Get animator component ref and satrt the loop Coroutine
        anim = GetComponent<Animator>();
        StartCoroutine("SpitFire");
    }

    IEnumerator SpitFire()
    {
        
        yield return new WaitForSeconds(coolDownTime);
        //After coolDown time start the fire animation
        anim.SetTrigger("Fire");
        //restart Coroutine
        StartCoroutine("SpitFire");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If comes in contact with player
        if (other.tag == "Player")
        {
            //Check if is the dangerous parts of the Mob
            if(this.gameObject.tag == "Fire" || this.gameObject.tag == "Spike")
                //Send kill info
            other.GetComponent<Die>().KillPlayer();
        }
    }
}
