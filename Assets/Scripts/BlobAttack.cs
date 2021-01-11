using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAttack : MonoBehaviour
{
    // This script is given to the Blob monster and kills the player if they come in contact with each other
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Die>().KillPlayer();
        }
    }
}
