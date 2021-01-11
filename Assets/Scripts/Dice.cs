using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dice : MonoBehaviour
{
    // EndGame spript
    // Text to show the last score and the highest score ever Recorded by the player 
    public Text score;
    public Text highScore;
    public ScoreCount CurrScore;
    

     void Awake()
    {
        // Find the Ui elements that will display the scores
        score = GameObject.FindGameObjectWithTag("Cur Score").GetComponent<Text>();
        highScore = GameObject.FindGameObjectWithTag("High Score").GetComponent<Text>();
        // Find ScoreCount script to get the necessary info
        CurrScore = GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void RollDice()
    {
        
        score.text = CurrScore.MaxScore.ToString();
        //Check if the lastScore was higher than the last recorded high score
        if (CurrScore.MaxScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // if it is then ajust the high score text and playerPref
            highScore.text = CurrScore.MaxScore.ToString();
            PlayerPrefs.SetInt("HighScore", CurrScore.MaxScore);
        }
        
    }
    //Restart the game by reloading the game scene that is the scene one
    public void Reset()
    {
        SceneManager.LoadScene(1);
    }
    //Goes back to menu by loading the scene zero that is the menu scene
    public void Exit()
    {
        SceneManager.LoadScene(0);
        
    }
    
}
