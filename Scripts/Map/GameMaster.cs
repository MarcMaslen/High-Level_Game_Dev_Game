using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    //I used some of my knowledge from lab 1 to make the wave system
    public Text currentWave;
    public Text zombiesKilled;
    
    //holds in game values
    public int count;
    public int wave;
    public int xp;
    public int killCounter;

    //This counts the zombies killed, when it hits 10 the wave goes up and is reset back to 0
    void Update(){
        if(count == 15){ //when the zombie death count is 15, add 1 to the wave
            wave++;  
            count = 0;
        }

        zombiesKilled.text = "Zombies Slain: " + killCounter.ToString(); //when the zombie is killed, add 1 to the kill counter

    }

    void Start(){ //sets the wave to 0 and the zombie death count to 0
        count = 0;
        wave = 0;
        killCounter = 0;
        xp = 0;
        SetCountText();

        //hides mouse cursor
        Cursor.visible = false;
    }

    //sets the current wave text
    public void SetCountText(){
        currentWave.text = "Waves: " + wave.ToString();
    }
}
