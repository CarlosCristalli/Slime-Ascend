using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Void when called loads the scene zero witch is the menu
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
