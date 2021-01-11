using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMaker : MonoBehaviour
{
    //Medim size pad ref
    public GameObject M;
    //Small size pad ref
    public GameObject P;
    //Meteor ref
    public GameObject Meteor;
    //Coins ref
    public GameObject Coin;
    //Array of possible boosts
    public GameObject[] Boosts;
    //Array of possible Enemies
    public GameObject[] Enemies;
    //Array of possible pads (Medium, small and meteor)
    GameObject[] Plataforms = new GameObject[3];
    public GameObject[] Backgrounds;

    int rand = 0;
    int randomSpawnBonus = 0;


    float randomXPos;
    // Start is called before the first frame update
    void Awake()
    {
        //Fill the Plataform array with the M , S and Meteeor gameObject
        Plataforms[0] = P;
        Plataforms[1] = M;
        Plataforms[2] = Meteor;
        // from 0 to 1200 go Up by a random num 3 to 10
        for (int i = 0; i < 1200; i += Random.Range(3, 10))
        {
            //Pos in X can varie from -5 to 5
            randomXPos = Random.Range(-5f, 5f);
            //Place random Background image to populate the ascend visualy
            Instantiate(Backgrounds[Random.Range(0,Backgrounds.Length)], new Vector3(randomXPos, i, 0), Quaternion.identity);
        }

            for (int i = 0; i < 1200; i+=Random.Range(3,5))
        {
            //Randomize is use to select if or what bonus will be spawned in that pad
            randomSpawnBonus = rand = Random.Range(1, 30);
            //Pos in X can varie from -3.5f to 3.5f
            randomXPos = Random.Range(-3.5f, 3.5f);
            //If the heigh is lower then 800 can only spawn M or S
            if (i< 800)
            {
                rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    Instantiate(M, new Vector3(randomXPos, i, 0), Quaternion.identity);
                }
                if (rand == 2)
                {
                    Instantiate(P, new Vector3(randomXPos, i, 0), Quaternion.identity);
                }
            }
            else
            {
                //If the heigh is Heigher then 800 can spawn all pads
                Instantiate(Plataforms[Random.Range(0,Plataforms.Length)], new Vector3(randomXPos, i, 0), Quaternion.identity);
            }
            //Spawns a coin in that pad
            if(randomSpawnBonus >= 5 && randomSpawnBonus <= 10)
            {

                Instantiate(Coin, new Vector3(randomXPos, i+2, 0), Quaternion.identity);
            }
            //Spawns a random boost in that pad
            else if (randomSpawnBonus == 4)
            {
                int rando = Random.Range(0, Boosts.Length);
                Instantiate(Boosts[rando], new Vector3(randomXPos, i + 2, 0), Quaternion.identity);

            }
            //Spawns a Mob in that pad
            else if (randomSpawnBonus >= 1 && randomSpawnBonus <= 3 && i > 500)
            {
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(randomXPos, i + 2, 0), Quaternion.identity);
            }
        }
    }
}
