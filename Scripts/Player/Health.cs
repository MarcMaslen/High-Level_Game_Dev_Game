using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, DataSaveLoad
{

    private zombie_movement zombieMovement;
    public Text healthText;
    public int health = 100;



    //displays health to the player
    void Update(){

        healthText.text = "Health: " + health.ToString();
    }

    //when a player collides with a zombie they will take damage. 
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "enemy"){
            Debug.Log("hit");
            health -= 10;
        }
    }

    //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.health += gameData.extraHealth;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
      
    }
    
}
