using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermUpgrades : MonoBehaviour, DataSaveLoad
{
    private int permLevel; //level of the account
    public int skillPoints; //number of skill points availble
    private int extraDamage; //extra damage
    private int extraHealth; //extra health
    private int extraSpeed;  //extra speed
    private int gunActive = 0; //which gun is active

    public Text permLevelText;
    public Text skillPointsText;
    public Text gunActiveText;
    public GameObject bullet;
    public GameObject player;
    private Upgrades upgrades;
    public Button gun;
    

    // Start is called before the first frame update
    void Start()
    {
        //starts the game and updates the level and points availble 
        skillPointsText.text = "Points:" + skillPoints.ToString();
        permLevelText.text = "Level:" + permLevel.ToString();

        //gets the components so we can upgrade them
        player.GetComponent<Health>().health += extraHealth;
        bullet.GetComponent<bullet>().damage += extraDamage;
        player.GetComponent<Player_movement>().moveSpeed += extraSpeed;
         
         if (gunActive == 1){ //if the gun is active then it will change the text to say so
            gunActiveText.text = "SOLD"; 
            gun.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {   
        //upgrades text when they change 
        skillPointsText.text = "SP:" + skillPoints.ToString();
        permLevelText.text = "Level:" + permLevel.ToString();

    }
    
    //this will increase the bullet damage
    public void GunDamage(){
        if (skillPoints >= 5){
            skillPoints -= 5;
            extraDamage += 5;
            permLevel += 1;
            permLevelText.text = "Level:" + permLevel.ToString();
            bullet.GetComponent<bullet>().damage += 5;
        }
    }

    //this will increase the player health
    public void HealthIncrease(){
        if (skillPoints >= 5){
            skillPoints -= 5;
            extraHealth += 10;
            permLevel += 1;
            permLevelText.text = "Level:" + permLevel.ToString();
            player.GetComponent<Health>().health += 10;
        }
    }

    //this will increase the player speed
    public void SpeedIncrease(){
        if (skillPoints >= 5){
            skillPoints -= 5;
            extraSpeed += 5;
            permLevel += 1;
            permLevelText.text = "Level:" + permLevel.ToString();
            player.GetComponent<Player_movement>().moveSpeed += 5;
        }
    }

    //this will change the gun to the SMG, which is expensive but better
    public void GunUpgrade(){
        if (skillPoints >= 25){
            skillPoints -= 25;
            permLevel += 1;
            gunActive = 1;
            permLevelText.text = "Level:" + permLevel.ToString();
            gun.enabled = false;
            gunActiveText.text = "SOLD"; 
        }
    }



    //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.permLevel = gameData.permLevel;
        this.skillPoints = gameData.skillPoints;
        this.extraDamage = gameData.extraDamage;
        this.extraHealth = gameData.extraHealth;
        this.extraSpeed = gameData.extraSpeed;
        this.gunActive = gameData.gunActive;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
        gameData.permLevel = this.permLevel;
        gameData.skillPoints = this.skillPoints;
        gameData.extraDamage = this.extraDamage;
        gameData.extraHealth = this.extraHealth;
        gameData.extraSpeed = this.extraSpeed;
        gameData.gunActive = this.gunActive;
    }
}
