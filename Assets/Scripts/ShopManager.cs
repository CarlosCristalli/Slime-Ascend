using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text ShieldPriceText;
    public Text JumpPriceText;
    public Text MagnetPriceText;
    public Text EspecialPriceText;



    public Button ShildButton;
    public Button JumpButton;
    public Button MagnetButton;
    public Button EspecialButton;

    public Slider ShildSlider;
    public Slider JumpSlider;
    public Slider MagnetSlider;
    public Slider EspecialSlider;

    //public GameObject YouCantBuyThat;

    int ShieldPrice = 15;
    int JumpPrice = 15;
    int MagnetPrice = 15;
    int EspecialPrice = 100;

    int ShieldPriceProgretionRate = 2;
    int JumpPriceProgretionRate = 2;
    int MagnetPriceProgretionRate = 2;
    int EspecialPriceProgretionRate = 2;

    int ShieldID = 0;
    int JumpID = 0;
    int MagnetID = 0;
    int EspecialID = 0;

    public int numOfCoins;
    public Text numOfCoinsText;

    float ShieldPowerProgretionRate = 0.5f;
    float JumpPowerProgretionRate = 0.2f;
    float MagnetPowerProgretionRate = 0.5f;
    float EspecialPowerProgretionRate = 0.2f;

    float JumpBuff;


    public Text IceSlimePriceText;
    public Text TimeSlimePriceText;

    public Button IceSlimeButton;
    public Button TimeSlimeButton;

    public Text IceSlimeBuyText1;
    public Text IceSlimeBuyText2;
    public Text TimeSlimeBuyText1;
    public Text TimeSlimeBuyText2;

    bool IceSlimeIsBought = false;
    bool TimeSlimeIsBought = false;

    public int CommomSlimePrice = 1000;

    int numOfItemsInStore = 11;
    public int[] Prices;

    void Awake()
    {
        Prices = new int[numOfItemsInStore];
        // Sets the defult Price and Boost values
        PlayerPrefs.SetFloat("JumpMultiplyer", 2);
        ShieldID = PlayerPrefs.GetInt("ShildID", 0);
        ShieldPrice = PlayerPrefs.GetInt("ShildPrice", 15);
        JumpID = PlayerPrefs.GetInt("JumpID");
        JumpPrice = PlayerPrefs.GetInt("JumpPrice", 15);
        MagnetID = PlayerPrefs.GetInt("MagnetID", 0);
        MagnetPrice = PlayerPrefs.GetInt("MagnetPrice", 15);
        EspecialID = PlayerPrefs.GetInt("TimeID", 0);
        EspecialPrice = PlayerPrefs.GetInt("TimePrice", 100);
    }
    void Start()
    {

       Debug.Log( PlayerPrefs.GetInt("HatThatIsUsing"));
    }

    void Update()
    {
        // checks if the one purses items have been already been bought
        CheckIfBallonIsBought();
        CheckIfBaseballIsBought();
        CheckIfMedievalIsBought();
        CheckIfWizardIsBought();
        CheckIfIceSlimeIsBought();
        CheckIfTimeSlimeIsBought();
        // Upadating the Sliders values according to how many times they have been bought
        ShildSlider.value = ShieldID;
        JumpSlider.value = JumpID;
        MagnetSlider.value = MagnetID;
        EspecialSlider.value = EspecialID;
        // Updating the Texts on Screen
        ShieldPriceText.text = ShieldPrice.ToString() + " coins";
        JumpPriceText.text = JumpPrice.ToString() + " coins";
        MagnetPriceText.text = MagnetPrice.ToString() + " coins";
        EspecialPriceText.text = EspecialPrice.ToString() + " coins";
        //Compacting the number of coins text
        numOfCoins = PlayerPrefs.GetInt("Coin");
        if (numOfCoins > 9999)
        {
            if(numOfCoins > 999999)
            {
                numOfCoinsText.text = (numOfCoins / 1000000).ToString() + "m";
            }
            else
            {
                numOfCoinsText.text = (numOfCoins / 1000).ToString() + "k";
            }
            
        }
        else { numOfCoinsText.text = numOfCoins.ToString(); }

        

        if(numOfCoins < ShieldPrice)
        {
            //ShildButton.enabled = false;
        }else ShildButton.enabled = true;

        if(numOfCoins < JumpPrice)
        {
            //JumpButton.enabled = false;
        }else JumpButton.enabled = true;

        if (numOfCoins < MagnetPrice)
        {
            //MagnetButton.enabled = false;
        }
        else MagnetButton.enabled = true;

        if (numOfCoins < EspecialPrice)
        {
            //EspecialButton.enabled = false;
        }
        else EspecialButton.enabled = true;

        UpdatePriceArray();

    }
    void UpdatePriceArray()
    {
        Prices[0] = ShieldPrice;
        Prices[1] = JumpPrice;
        Prices[2] = MagnetPrice;
        Prices[3] = EspecialPrice;
        Prices[4] = comonHatPrice;
        Prices[5] = CommomSlimePrice;
    }

    public void BuyShield()
    {
        if(numOfCoins >= ShieldPrice)
        {
            ShieldID = PlayerPrefs.GetInt("ShildID",0);
            ShieldPrice = PlayerPrefs.GetInt("ShildPrice", 15);

            PlayerPrefs.SetFloat("ShildFadeTime", (PlayerPrefs.GetFloat("ShildFadeTime", 5)+ ShieldPowerProgretionRate));
            numOfCoins -= ShieldPrice;
            ShieldPrice *= ShieldPriceProgretionRate;
            ShieldID++;
            PlayerPrefs.SetInt("ShildID", ShieldID);
            PlayerPrefs.SetInt("ShildPrice", ShieldPrice);

            
            PlayerPrefs.SetInt("Coin", numOfCoins);

        }
    }
    // Here Starts the Boosts Area

    public void BuyJump()
    {
        if (numOfCoins >= JumpPrice)
        {
            JumpID = PlayerPrefs.GetInt("JumpID");
            JumpPrice = PlayerPrefs.GetInt("JumpPrice", 15);


            JumpBuff = PlayerPrefs.GetFloat("JumpMultiplyer");


            PlayerPrefs.SetFloat("JumpMultiplyer", (JumpBuff + JumpPowerProgretionRate));
            Debug.Log(JumpBuff);
            Debug.Log(PlayerPrefs.GetFloat("JumpMultiplyer"));
            numOfCoins -= JumpPrice;
            JumpPrice *= JumpPriceProgretionRate;
            JumpID++;
            PlayerPrefs.SetInt("JumpID", JumpID);
            PlayerPrefs.SetInt("JumpPrice", JumpPrice);

            
            PlayerPrefs.SetInt("Coin", numOfCoins);
        }
    }
    public void BuyMagnet()
    {
        if (numOfCoins >= MagnetPrice)
        {

            MagnetID = PlayerPrefs.GetInt("MagnetID", 0);
            MagnetPrice = PlayerPrefs.GetInt("MagnetPrice", 15);

            PlayerPrefs.SetFloat("MagnetFadeTime", (PlayerPrefs.GetFloat("MagnetFadeTime") + MagnetPowerProgretionRate));
            numOfCoins -= MagnetPrice;
            MagnetPrice *= MagnetPriceProgretionRate;
            MagnetID++;

            PlayerPrefs.SetInt("MagnetID", MagnetID);
            PlayerPrefs.SetInt("MagnetPrice", MagnetPrice);

            
            PlayerPrefs.SetInt("Coin", numOfCoins);
        }
    }
    public void BuyTime()
    {
        if (numOfCoins >= EspecialPrice)
        {
            EspecialID = PlayerPrefs.GetInt("TimeID", 0);
            EspecialPrice = PlayerPrefs.GetInt("TimePrice", 100);

            PlayerPrefs.SetFloat("TimeFadeTime", (PlayerPrefs.GetFloat("TimeFadeTime", 1) + EspecialPowerProgretionRate));
            numOfCoins -= EspecialPrice;
            EspecialPrice *= EspecialPriceProgretionRate;
            EspecialID++;

            PlayerPrefs.SetInt("TimeID", EspecialID);
            PlayerPrefs.SetInt("TimePrice", EspecialPrice);

            
            PlayerPrefs.SetInt("Coin", numOfCoins);
        }
    }

    // Here Starts the Hats Area
    public HatsCustom PutHat;

    int comonHatPrice = 100;

    public Text BallonHatBuyText1;
    public Text BallonHatBuyText2;
    public Text BallonHatPrice;

    bool BallonHatIsBought = false;

    

    public void BuyHatBalloon()
    {
        if (numOfCoins >= comonHatPrice)
        {
            if (PlayerPrefs.GetInt("BallonHatIsBought") == 0)
            {
                BallonHatIsBought = false;
            }
            if (PlayerPrefs.GetInt("BallonHatIsBought") == 1)
            {
                BallonHatIsBought = true;
            }
            if (!BallonHatIsBought)
            {
                BallonHatBuyText1.text = "Equip";
                BallonHatBuyText2.text = "Equip";
                BallonHatIsBought = true;
                numOfCoins -= comonHatPrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("BallonHatIsBought", 1);
                BallonHatPrice.gameObject.SetActive(false);

            }
            
        }
        if (BallonHatIsBought)
        {
            if (BallonHatBuyText1.text == "Equiped")
            {
                BallonHatBuyText1.text = "Equip";
                BallonHatBuyText2.text = "Equip";
                PlayerPrefs.SetInt("HatThatIsUsing", 0);
            }
            else {
                BallonHatBuyText1.text = "Equiped";
                BallonHatBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("HatThatIsUsing", 1);
                PutHat.Balloon();
            }
        }
    }
    void CheckIfBallonIsBought()
    {
        if (PlayerPrefs.GetInt("BallonHatIsBought") == 0)
        {
            BallonHatIsBought = false;
        }
        if (PlayerPrefs.GetInt("BallonHatIsBought") == 1)
        {
            BallonHatIsBought = true;
        }
        if (BallonHatIsBought)
        {
            BallonHatBuyText1.text = "Equip";
            BallonHatBuyText2.text = "Equip";
            if (PlayerPrefs.GetInt("HatThatIsUsing") == 1)
            {
                BallonHatBuyText1.text = "Equiped";
                BallonHatBuyText2.text = "Equiped";
            }

        }
    }
    public Text BaseballHatBuyText1;
    public Text BaseballHatBuyText2;
    public Text BaseballHatPrice;

    bool BaseballHatIsBought = false;



    public void BuyHatBaseball()
    {
        if (numOfCoins >= comonHatPrice)
        {
            if (PlayerPrefs.GetInt("BaseballHatIsBought") == 0)
            {
                BaseballHatIsBought = false;
            }
            if (PlayerPrefs.GetInt("BaseballHatIsBought") == 1)
            {
                BaseballHatIsBought = true;
            }
            if (!BaseballHatIsBought)
            {
                BaseballHatBuyText1.text = "Equip";
                BaseballHatBuyText2.text = "Equip";
                BaseballHatIsBought = true;
                numOfCoins -= comonHatPrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("BaseballHatIsBought", 1);
                BaseballHatPrice.gameObject.SetActive(false);

            }
            
        }
        if (BaseballHatIsBought)
        {
            if (BaseballHatBuyText1.text == "Equiped")
            {
                BaseballHatBuyText1.text = "Equip";
                BaseballHatBuyText2.text = "Equip";
                PlayerPrefs.SetInt("HatThatIsUsing", 0);
            }
            else {
                BaseballHatBuyText1.text = "Equiped";
                BaseballHatBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("HatThatIsUsing", 2);
                PutHat.Baseball();
            }
        }
    }
    void CheckIfBaseballIsBought()
    {
        if (PlayerPrefs.GetInt("BaseballHatIsBought") == 0)
        {
            BaseballHatIsBought = false;
        }
        if (PlayerPrefs.GetInt("BaseballHatIsBought") == 1)
        {
            BaseballHatIsBought = true;
        }
        if (BaseballHatIsBought)
        {
            BaseballHatBuyText1.text = "Equip";
            BaseballHatBuyText2.text = "Equip";
            if (PlayerPrefs.GetInt("HatThatIsUsing") == 2)
            {
                BaseballHatBuyText1.text = "Equiped";
                BaseballHatBuyText2.text = "Equiped";
            }

        }
    }


    public Text MedievalHatBuyText1;
    public Text MedievalHatBuyText2;
    public Text MedievalHatPrice;

    bool MedievalHatIsBought = false;



    public void BuyHatMedieval()
    {
        if (numOfCoins >= comonHatPrice)
        {
            if (PlayerPrefs.GetInt("MedievalHatIsBought") == 0)
            {
                MedievalHatIsBought = false;
            }
            if (PlayerPrefs.GetInt("MedievalHatIsBought") == 1)
            {
                MedievalHatIsBought = true;
            }
            if (!MedievalHatIsBought)
            {
                MedievalHatBuyText1.text = "Equip";
                MedievalHatBuyText2.text = "Equip";
                MedievalHatIsBought = true;
                numOfCoins -= comonHatPrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("MedievalHatIsBought", 1);
                MedievalHatPrice.gameObject.SetActive(false);
            }
            
        }
        if (MedievalHatIsBought)
        {
            if (MedievalHatBuyText1.text == "Equiped")
            {
                MedievalHatBuyText1.text = "Equip";
                MedievalHatBuyText2.text = "Equip";
                PlayerPrefs.SetInt("HatThatIsUsing", 0);
            }
            else {
                MedievalHatBuyText1.text = "Equiped";
                MedievalHatBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("HatThatIsUsing", 3);
                PutHat.Medieval();
            }
        }
    }
    void CheckIfMedievalIsBought()
    {
        if (PlayerPrefs.GetInt("MedievalHatIsBought") == 0)
        {
            MedievalHatIsBought = false;
        }
        if (PlayerPrefs.GetInt("MedievalHatIsBought") == 1)
        {
            MedievalHatIsBought = true;
        }
        if (MedievalHatIsBought)
        {
            MedievalHatBuyText1.text = "Equip";
            MedievalHatBuyText2.text = "Equip";
            if (PlayerPrefs.GetInt("HatThatIsUsing") == 3)
            {
                MedievalHatBuyText1.text = "Equiped";
                MedievalHatBuyText2.text = "Equiped";
            }

        }
    }


    public Text WizardHatBuyText1;
    public Text WizardHatBuyText2;
    public Text WizardHatPrice;

    bool WizardHatIsBought = false;



    public void BuyHatWizard()
    {
        if (numOfCoins >= comonHatPrice)
        {
            if (PlayerPrefs.GetInt("WizardHatIsBought") == 0)
            {
                WizardHatIsBought = false;
            }
            if (PlayerPrefs.GetInt("WizardHatIsBought") == 1)
            {
                WizardHatIsBought = true;
            }
            if (!WizardHatIsBought)
            {
                WizardHatBuyText1.text = "Equip";
                WizardHatBuyText2.text = "Equip";
                WizardHatIsBought = true;
                numOfCoins -= comonHatPrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("WizardHatIsBought", 1);
                WizardHatPrice.gameObject.SetActive(false);
            }
            
        }
        if (WizardHatIsBought)
        {
            if (WizardHatBuyText1.text == "Equiped")
            {
                WizardHatBuyText1.text = "Equip";
                WizardHatBuyText2.text = "Equip";
                PlayerPrefs.SetInt("HatThatIsUsing", 0);
            }
            else{
                WizardHatBuyText1.text = "Equiped";
                WizardHatBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("HatThatIsUsing", 4);
                PutHat.Wizard();
            }
        }
    }
    void CheckIfWizardIsBought()
    {
        if (PlayerPrefs.GetInt("WizardHatIsBought") == 0)
        {
            WizardHatIsBought = false;
        }
        if (PlayerPrefs.GetInt("WizardHatIsBought") == 1)
        {
            WizardHatIsBought = true;
        }
        if (WizardHatIsBought)
        {
            WizardHatBuyText1.text = "Equip";
            WizardHatBuyText2.text = "Equip";
            if (PlayerPrefs.GetInt("HatThatIsUsing") == 4)
            {
                WizardHatBuyText1.text = "Equiped";
                WizardHatBuyText2.text = "Equiped";
            }

        }
    }

    // Here Starts the Slimes Area
    public void BuyIceSlime()
    {
        if (numOfCoins >= CommomSlimePrice)
        {
            if (PlayerPrefs.GetInt("IceSlimeIsBought") == 0)
            {
                IceSlimeIsBought = false;
            }
            if (PlayerPrefs.GetInt("IceSlimeIsBought") == 1)
            {
                IceSlimeIsBought = true;
            }
            if (!IceSlimeIsBought)
            {
                IceSlimeBuyText1.text = "Equip";
                IceSlimeBuyText2.text = "Equip";
                IceSlimeIsBought = true;
                numOfCoins -= CommomSlimePrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("IceSlimeIsBought", 1);

            }

        }
        if (IceSlimeIsBought)
        {
            if(IceSlimeBuyText1.text == "Equiped")
            {
                IceSlimeBuyText1.text = "Equip";
                IceSlimeBuyText2.text = "Equip";
                PlayerPrefs.SetInt("SlimeOfChoice", 0);
            }
            else
            {
                IceSlimeBuyText1.text = "Equiped";
                IceSlimeBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("SlimeOfChoice", 1);
            }
            
            
        }
    }
    void CheckIfIceSlimeIsBought()
    {
        if (PlayerPrefs.GetInt("IceSlimeIsBought") == 0)
        {
            IceSlimeIsBought = false;
        }
        if (PlayerPrefs.GetInt("IceSlimeIsBought") == 1)
        {
            IceSlimeIsBought = true;
        }
        if (IceSlimeIsBought)
        {
            IceSlimeBuyText1.text = "Equip";
            IceSlimeBuyText2.text = "Equip";
            IceSlimePriceText.text = "";
            if (PlayerPrefs.GetInt("SlimeOfChoice") == 1)
            {
                IceSlimeBuyText1.text = "Equiped";
                IceSlimeBuyText2.text = "Equiped";
            }

        }
    }

    public void BuyTimeSlime()
    {
        if (numOfCoins >= CommomSlimePrice)
        {
            if (PlayerPrefs.GetInt("TimeSlimeIsBought") == 0)
            {
                TimeSlimeIsBought = false;
            }
            if (PlayerPrefs.GetInt("TimeSlimeIsBought") == 1)
            {
                TimeSlimeIsBought = true;
            }
            if (!TimeSlimeIsBought)
            {
                TimeSlimeBuyText1.text = "Equip";
                TimeSlimeBuyText2.text = "Equip";
                TimeSlimeIsBought = true;
                numOfCoins -= CommomSlimePrice;
                PlayerPrefs.SetInt("Coin", numOfCoins);
                PlayerPrefs.SetInt("TimeSlimeIsBought", 1);

            }

        }
        if (TimeSlimeIsBought)
        {
            if (TimeSlimeBuyText1.text == "Equiped")
            {
                TimeSlimeBuyText1.text = "Equip";
                TimeSlimeBuyText2.text = "Equip";
                PlayerPrefs.SetInt("SlimeOfChoice", 0);
            }
            else
            {
                TimeSlimeBuyText1.text = "Equiped";
                TimeSlimeBuyText2.text = "Equiped";
                PlayerPrefs.SetInt("SlimeOfChoice", 2);
            }
            
            Debug.Log(PlayerPrefs.GetInt("SlimeOfChoice"));
            
        }
    }
    void CheckIfTimeSlimeIsBought()
    {
        
        if (PlayerPrefs.GetInt("TimeSlimeIsBought") == 0)
        {
            TimeSlimeIsBought = false;
        }
        if (PlayerPrefs.GetInt("TimeSlimeIsBought") == 1)
        {
            TimeSlimeIsBought = true;
        }
        if (TimeSlimeIsBought)
        {
            TimeSlimeBuyText1.text = "Equip";
            TimeSlimeBuyText2.text = "Equip";
            TimeSlimePriceText.text = "";
            if (PlayerPrefs.GetInt("SlimeOfChoice") == 2)
            {
                
                TimeSlimeBuyText1.text = "Equiped";
                TimeSlimeBuyText2.text = "Equiped";
            }

        }
    }

    // This is a method to debug and reset the store
    public void ResetStuff()
    {
        PlayerPrefs.SetInt("Coin", 1500);
        PlayerPrefs.SetInt("BallonHatIsBought", 0);
        PlayerPrefs.SetInt("BaseballHatIsBought", 0);
        PlayerPrefs.SetInt("MedievalHatIsBought", 0);
        PlayerPrefs.SetInt("WizardHatIsBought", 0);
        PlayerPrefs.SetInt("HatThatIsUsing", 0);
        PlayerPrefs.DeleteKey("TimeFadeTime");
        PlayerPrefs.DeleteKey("MagnetFadeTime");
        PlayerPrefs.DeleteKey("JumpMultiplyer");
        PlayerPrefs.DeleteKey("ShildFadeTime");

        PlayerPrefs.DeleteKey("TimeID");
        PlayerPrefs.DeleteKey("TimePrice");

        PlayerPrefs.DeleteKey("MagnetID");
        PlayerPrefs.DeleteKey("MagnetPrice");

        PlayerPrefs.DeleteKey("JumpID");
        PlayerPrefs.DeleteKey("JumpPrice");

        PlayerPrefs.DeleteKey("ShildID");
        PlayerPrefs.DeleteKey("ShildPrice");

        PlayerPrefs.SetInt("TimeSlimeIsBought", 0);
        PlayerPrefs.SetInt("IceSlimeIsBought", 0);
        PlayerPrefs.SetInt("SlimeOfChoice", 0);


    }
}
