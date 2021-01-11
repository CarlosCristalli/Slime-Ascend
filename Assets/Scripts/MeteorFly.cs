using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFly : MonoBehaviour
{
    Rigidbody2D rb;


    public int horizontalSpeed = 1;

    // Start is called before the first frame update
    void Awake()
    {
        //Locates the Flying object Rigidbody
        rb = GetComponent<Rigidbody2D>();
        //flight speed
        horizontalSpeed = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontalSpeed == 0)
        {
            //resets flight speed
            horizontalSpeed = Random.Range(-1, 2);
        }
        //Turns it around
        if(transform.position.x >= 8)
        {
            transform.position = new Vector3(-8f, transform.position.y, transform.position.z);
            horizontalSpeed = 1;

        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(8f, transform.position.y, transform.position.z);
            horizontalSpeed = -1;
        }
    }

    void FixedUpdate()
    {
        //Spins the image
        if(horizontalSpeed < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        //sets the rb velocity
        rb.velocity = new Vector2(horizontalSpeed*5, 0);
    }
}
