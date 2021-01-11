using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Void of the main buttons in the menu

    //Start the Game
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    //Quits the App
    public void Exit()
    {
        Application.Quit();
    }
    //Loads the shop scene
    public void Shop()
    {
        SceneManager.LoadScene(2);
    }
}
