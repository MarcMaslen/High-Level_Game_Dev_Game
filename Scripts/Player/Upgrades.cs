using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour, DataSaveLoad
{
    private xpbar xpbar;

    [Header("Level Up stats")]
    public GameObject LevelUpScreen;
    public GameObject MainPlayer;
    public GameObject Gun;
    public GameObject bullet;
    public GameObject player;
    public int level;
    public int skillPoint;

    // Start is called before the first frame update
    void Start()
    {
        LevelUpScreen.SetActive(false); //sets the level up screen to false
        xpbar = GameObject.FindGameObjectWithTag("XPBar").GetComponent<xpbar>(); //gets the xpbar script
        
    }

    // Update is called once per frame
    void Update()
    {
        if (xpbar.isLevelUp == true){ //if the xpbar script says the player has leveled up then level up 
            LevelUp(); //calls the level up function
            level++; //increases the level
        }

        //every 5 in-game levels it will award the player with a skill point for a permanent stat increase
        if (level == 1){
            skillPoint += 1;
            Debug.Log("You have earned a skill point");
            level = 0;
        }
    }

    //the reason for turning so many functions off is because we want everything to freeze but the level up screen
    public void LevelUp(){
        LevelUpScreen.SetActive(true); //sets the level up screen to true 
        MainPlayer.GetComponent<Player_movement>().enabled = false; //disables the player movement script
        Gun.GetComponent<shooting>().enabled = false; //disables the shooting script
        Cursor.lockState = CursorLockMode.None; //unlocks the cursor
        Cursor.visible = true; //makes the cursor visible
        Time.timeScale = 0; //pauses the game
    }

    //these functions will increase the stats of the player and also unfreeze everything again to continue the game

    public void GunDamage(){
        bullet.GetComponent<bullet>().damage += 5; //increases the damage of the bullet
        LevelUpScreen.SetActive(false); //sets the level up screen to false
        MainPlayer.GetComponent<Player_movement>().enabled = true; //enables the player movement script
        Gun.GetComponent<shooting>().enabled = true; //enables the shooting script
        Time.timeScale = 1; //unpauses the game
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor
        Cursor.visible = false; //makes the cursor invisible
    }

    
    public void HealthIncrease(){ 
        player.GetComponent<Health>().health += 10; //increases the health of the player
        LevelUpScreen.SetActive(false); 
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SpeedIncrease(){
        player.GetComponent<Player_movement>().moveSpeed += 5; //increases the speed of the player
        LevelUpScreen.SetActive(false);
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

     //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
        gameData.skillPoints += this.skillPoint;
    }
}
