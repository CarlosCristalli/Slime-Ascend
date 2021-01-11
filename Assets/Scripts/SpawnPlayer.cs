using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    //Ref to all slimes
    public GameObject[] Slimes;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Awake()
    {
        //Get slime of choice from player pref and spawns it
        
        if (PlayerPrefs.GetInt("SlimeOfChoice",0) == 0)
        {
            Instantiate(Slimes[0], new Vector3(0, 0.89f, 0),Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("SlimeOfChoice") == 1)
        {
            Instantiate(Slimes[1], new Vector3(0, 0.89f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("SlimeOfChoice") == 2)
        {
            Instantiate(Slimes[2], new Vector3(0, 0.89f, 0), Quaternion.identity);
        }
    }
    void Start()
    {
        EndScreen.SetActive(false);
    }
    
}
