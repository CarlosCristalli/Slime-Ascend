using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text Score;
    GameObject Player;
    public int CurrScore;
    public int MaxScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Transforms the player height in the score
        CurrScore = (int)Player.transform.position.y;
        //displays the score
        Score.text = "Score: " + MaxScore.ToString();
        //If need be updates the maxScore
        if(CurrScore > MaxScore)
        {
            MaxScore = CurrScore;
        }

        
            
            
    }
}

