using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //we can save it in a file with this
public class PlayerData {

    public float musicLevel; //music level
    private MenuSettings menuSettings; //menu settings
    public int permLevel; //permanent player level
    public int skillPoints; //permanent skill points
    public float brightness; //brightness level

    //these are the extra stats that are added to the player when loaded
    public int extraDamage; 
    public int extraHealth; 
    public int extraSpeed;
    public int gunActive;
 

    //TO-DO:
    // - Add brightness settings - Done
    // - Add global player level - Done

    //These are the default values for the player data when starting a new game
    //when new values are saved they are overridden.
    public PlayerData (){
        musicLevel = .5f;
        permLevel = 0;
        brightness = 0;
        skillPoints = 0;
        extraDamage = 0;
        extraHealth = 0;
        extraSpeed = 0;
        gunActive = 0;
    }
    
}
