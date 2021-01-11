using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatsCustom : MonoBehaviour
{
    //Script to put hat in player during the game


    //Locate the Displays
    public SpriteRenderer PlayerHat1;
    public SpriteRenderer PlayerHat2;

    //IDs seting the to a higher num the de max Id so if the player has no hat it does nothing
    public static int Hat1ID = 5;
    public static int Hat2ID = 3;

    //Hats images ref
    public Sprite[] Hats;
    public Sprite[] HatsAddOns;

   

    void Awake()
    {
        //Look if the player has selected a hat by checking the playerPref
        if(PlayerPrefs.GetInt("HatThatIsUsing") == 1)
        {
            Balloon();
        }
        else if (PlayerPrefs.GetInt("HatThatIsUsing") == 2)
        {
            
            Baseball();
        }
        else if (PlayerPrefs.GetInt("HatThatIsUsing") == 3)
        {
            Medieval();
        }
        else if (PlayerPrefs.GetInt("HatThatIsUsing") == 4)
        {
            Wizard();
        }
    }
    void Start()
    {
        //Locate the displays images of the hat
        PlayerHat1 = GameObject.FindGameObjectWithTag("Hat1").GetComponent<SpriteRenderer>();
        PlayerHat2 = GameObject.FindGameObjectWithTag("Hat2").GetComponent<SpriteRenderer>();
        
    }

   //put image of selected hat in the display
    void Update()
    {
        if (PlayerHat1 != null)
        {

            PlayerHat1.sprite = Hats[Hat1ID];

            //if there is no sub hat deactivate subHat display
            if (Hat2ID == -1)
            {
                PlayerHat2.gameObject.SetActive(false);
            }
            else
            {
                PlayerHat2.sprite = HatsAddOns[Hat2ID];
            }
        }
            
        
        
    }
    //Change the HatSelected id to selected hat
    public void Balloon()
    {
        Hat1ID = 0;
        Hat2ID = 0;
    }
    public void Baseball()
    {
        
        Hat1ID = 1;
        Hat2ID = 1;
    }
    public void Wizard()
    {
        Hat1ID = 2;
        Hat2ID = 2;
    }
    public void Medieval()
    {
        Hat1ID = 3;
        Hat2ID = -1;
    }
    public void Viking()
    {
        Hat1ID = 4;
        Hat2ID = -1;
    }
}
