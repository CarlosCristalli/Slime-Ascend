using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{
    //Get info from boots manager
    BoostCollection Boosts;
    //Ref to animator
    public Animator anim;
    //CoolDownTime
    public float CoolDownTime = 2f;
    bool isCoolDownOver = true;
    //Special duration
    public float IceWallTime = 2f;
    //Effect
    bool IsKillableByFire = true;
    //RefToPlayer
    public GameObject Player;
    //Ref to special Display
    public GameObject IceWallImage;
    
    void Start()
    {
        //assing variables
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GameObject.FindGameObjectWithTag("Especial").GetComponent<Animator>();
        Boosts = Player.GetComponent<BoostCollection>();
    }
    //Spacial
    IEnumerator StartIceWall()
    {
        if (isCoolDownOver)
        {
            //If has been called and the coolDown is over Start animation and tur it unkillable by ifre
            anim.SetTrigger("IceActivate");
            IsKillableByFire = false;
            IceWallImage.GetComponent<SpriteRenderer>().enabled = true;
            IceWallImage.GetComponent<CircleCollider2D>().enabled = true;

            

            yield return new WaitForSeconds(IceWallTime);
            //After the time is over reset the coolDown and turn off the special
            isCoolDownOver = false;
            IsKillableByFire = true;
            //Disable the special display and colider
            IceWallImage.GetComponent<SpriteRenderer>().enabled = false;
            IceWallImage.GetComponent<CircleCollider2D>().enabled = false;
            //reset animation
            anim.ResetTrigger("IceActivate");
            //Start coolDown count
            StartCoroutine("IceWallCoolDown");
            
        }
    }
    IEnumerator IceWallCoolDown()
    {
        //Wait to end coolDown
            yield return new WaitForSeconds(CoolDownTime);
        isCoolDownOver = true;
    }
    // Update is called once per frame
    public void IceWallUse()
    {
        //Start special by calling StartIceWall coroutine
        StartCoroutine("StartIceWall");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //in the colision check if is killable by fire
        if (other.tag == "Fire" && !IsKillableByFire)
        {
            Boosts.Killable = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //in the end of the colision make it killable again
        if (other.tag == "Fire" && !IsKillableByFire)
        {
            Boosts.Killable = true;
        }
    }
}
