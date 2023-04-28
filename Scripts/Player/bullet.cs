using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour , DataSaveLoad
{
    public float distance;
    private GameMaster GameMaster;
    public int damage = 10;
    public int trackZombiesDefeated;
    private zombie_movement zombieMovement;
    //public int active = 0;


    void Awake(){
        Destroy(gameObject, distance); //Destroy the bullet after  distance reached. 
    }

    //finding the game object with tag GameMaster and enemy 
    void Start(){
        try{
            GameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
            zombieMovement = GameObject.FindGameObjectWithTag("enemy").GetComponent<zombie_movement>();
        } catch {
            Debug.Log("No Enemy's Spawned");
        }
    }

    //On collision with a enemy (zombie) they will be destroyed. If a bullet misses it will be destroyed.
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "enemy"){ //if collision is with enemy
            //active = 1; //set active to 1 for the damage numbers
            zombieMovement.zombieHealth -= damage; //minus health
            if(zombieMovement.zombieHealth <= 0){ //if zombie health hits 0
                Destroy(collision.gameObject); //destroy zombie
                GameMaster.count++;  //add to the count
                GameMaster.xp++; //add to the xp
                GameMaster.killCounter++; //add to the kill counter
                GameMaster.SetCountText(); //update the count text
            }

        } else if (collision.gameObject.tag == "ground") { //if bullet collides with ground
            Destroy(gameObject); //destroy bullet
        }
        Destroy(gameObject); //destroy bullet
        
    }

    //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.damage += gameData.extraDamage;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
      
    }

}
