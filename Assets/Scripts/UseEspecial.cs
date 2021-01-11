using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseEspecial : MonoBehaviour
{
    GameObject Player;
    PlayerMoviment MovPlayer;
    AddEspecial Especial;
    IceWall EspecialIce;
    
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MovPlayer = Player.GetComponent<PlayerMoviment>();
        Especial = Player.GetComponent<AddEspecial>();
        if (Especial.EspecialID == 1)
        {
            EspecialIce = GameObject.FindGameObjectWithTag("IceWall").GetComponent<IceWall>();
        }
    }

   //This is a input translator to detirminate witch special to activate based on what slime the player is using
    public void Use()
    {
        if(Especial.EspecialID == 2)
        {
            MovPlayer.midAirStop();
        }
        if (Especial.EspecialID == 1)
        {
            EspecialIce.IceWallUse();
        }
    }
}
