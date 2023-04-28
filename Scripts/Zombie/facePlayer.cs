using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour
{

    public GameObject player; //player
    public Transform target; //target
    private int smoothRotate = 10; //rotation speed 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //finds the player game object
        target = player.transform; //sets the target to the players transform 
        
    }

    //Every frame the zombie will update to smoothly fave the player
    void Update()
    {
        var rotation = Quaternion.LookRotation ( target.position - transform.position);  //updates the rotation to face the player
        transform.rotation = Quaternion.Slerp ( transform.rotation, rotation, Time.deltaTime * smoothRotate);  //smoothly rotates the zombie to face the player
    }
}
