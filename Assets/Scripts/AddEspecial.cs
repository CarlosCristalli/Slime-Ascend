using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddEspecial : MonoBehaviour
{
    public Animator anim;
    public Sprite EspecialImages;
    public int EspecialID;

    void Start()
    {
        // Seek for the GameObject responsible for handling the specials animation
        anim = GameObject.FindGameObjectWithTag("Especial").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Depending on which special is being used enables the respective animation
        if (EspecialID == 2)
        {
            anim.SetTrigger("EspecialIsTime");
        }
        if (EspecialID == 1)
        {
            anim.SetTrigger("EspecialIsIce");
        }



        
    }
}
