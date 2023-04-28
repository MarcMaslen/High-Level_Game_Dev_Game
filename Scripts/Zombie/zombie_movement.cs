using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_movement : MonoBehaviour
{
    //Zombie stats
    public float zombieSpeed = 1.0f; //speed of zombie
    public int zombieHealth = 20; //health of zombie
    public int zombieDamage = 10; //damage of zombie

    //Variables so the zombie targets the player
    public GameObject player; //player
    public Transform target; //target which is the player

    void Start(){
        //Finds the player
        player = GameObject.FindGameObjectWithTag("Player"); //finds the player game object
        target = player.transform; //sets the target to the players transform
    }
    

    void Update()
    {
        //this makes the zombie move forward at all times and as the zombie is locked onto the players transform it makes a good chase
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, zombieSpeed * Time.deltaTime); 
    }
    
    //Locks zombie from rotating on the y axis. 
    //Fix's bug: flying zombie, could be a cool feature for future game but not this one
    void LateUpdate() {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

    }


}
