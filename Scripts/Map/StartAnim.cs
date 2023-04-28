using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{   
    public GameObject anim;
    public GameObject spawners;
    public GameObject Gun1, Gun2;
    public GameObject MainPlayer;
    public GameObject MainPlayerUI;

    //when the scene starts disable the player and guns and set anything else to false
    void Start()
    {
        MainPlayer.GetComponent<Player_movement>().enabled = false;
        Gun1.GetComponent<shooting>().enabled = false;
        Gun2.GetComponent<shooting>().enabled = false;
        spawners.SetActive(false);
        MainPlayerUI.SetActive(false);
    }

    //when the animation is finished enable the player and guns and set anything else to true to start the level
    void StartGame(){
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun1.GetComponent<shooting>().enabled = true;
        Gun2.GetComponent<shooting>().enabled = true;
        spawners.SetActive(true);
        MainPlayerUI.SetActive(true);
        anim.SetActive(false);
    }
}
