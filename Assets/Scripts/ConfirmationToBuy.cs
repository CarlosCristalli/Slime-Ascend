using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationToBuy : MonoBehaviour
{
    // Ui Text to confirm purchase
    public Text Question;
    // Ui Buttons
    public Button Yes;
    public Button No;
    public Button Back;
    // Asset name
    public string ObjectToBuyname;
    // Asset price
    int Price;
   // Script of the Pop-Up confimation when buying in the store
   public void Accept()
    {
        // Send the info to the shopManager of witch method to run based on the string recived in the ReciveInfo method
        FindObjectOfType<ShopManager>().SendMessage("Buy" + ObjectToBuyname);
    }

    public void Decline()
    {

    }
    string text;
    public void GetIndexToKnowPrice(int index)
    {
        Price = FindObjectOfType<ShopManager>().Prices[index];
        string priceName = name + "Price";
    }
    public void ReciveInfo(string name)
    {
        // Recives the info depending on the Asset selected
        //If the player has enought coins open Buy popUp
        if (FindObjectOfType<ShopManager>().numOfCoins > Price)
        {
            text = "Are you sure you want to buy this Upgrade for " + Price.ToString() + " coins?";
            Debug.Log(text);
            Yes.gameObject.SetActive(true);
            No.gameObject.SetActive(true);
            Back.gameObject.SetActive(false);
        }
        //If the player hasnt enought coins open Buy popUp but dont activate the confirm button and change the text
        else
        {
            text = "You dont have enought coins to buy this item";
            Yes.gameObject.SetActive(false);
            No.gameObject.SetActive(false);
            Back.gameObject.SetActive(true);
        }
        Question.text = text;
        ObjectToBuyname = name;
        
    }
}
