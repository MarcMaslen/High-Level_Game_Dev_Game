using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    private Health health;
    public int healthPickup = 10;
    public GameObject healthPack;
    public float spawnTime = 8f;
    private float timer;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        maxHealth += health.health;
        spawnHealth();
    }

    //When a player walks to a health pack if they have less then max HP they can pick it up and gain 10 health back
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")&& health.health < maxHealth ){
            healthPack = other.gameObject;
            healthPack.gameObject.SetActive(false);
            health.health+= healthPickup;
        }
    }

    //Added this so that the health pack spawns back in after a certain amount of time
    void spawnHealth(){
        if(!healthPack.activeInHierarchy){
            timer += Time.deltaTime;
            if(timer > spawnTime){
                timer = 0;
                healthPack.SetActive(true);
                Debug.Log("Health Pack spawned");
            }
        }
    }
}
