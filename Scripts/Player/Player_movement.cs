using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour, DataSaveLoad
{

    //Player stats
    public float playerSpeed = 8.0F;
    public float moveSpeed = 20.0F;
    private Vector3 playerDirection = Vector3.zero;
    private float playerTurn;
    private float playerLook;
    public float mouseSen = 5;
    private CharacterController charController;
     
   
    void Start(){
        //Used a character controller to move the player
        charController = gameObject.GetComponent<CharacterController>();
    }

     void Update () {
      
        //Used to look on the x and y axis
         playerTurn = Input.GetAxis ("Mouse X") * mouseSen;
         playerLook = -Input.GetAxis ("Mouse Y") * mouseSen;

        //Looking left and right
        transform.eulerAngles += new Vector3 (0,playerTurn,0);
        transform.eulerAngles += new Vector3 (playerLook,0,0);

        //Moving forward and backwards, side to side
        playerDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerDirection = transform.TransformDirection(playerDirection);
        playerDirection *= playerSpeed;
        
        
         //Add moveSpeed to playerDirection.y and this allows the player to move with time.deltaTime.
         playerDirection.y -= moveSpeed * Time.deltaTime;
         charController.Move(playerDirection * Time.deltaTime);

     }

     //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.moveSpeed += gameData.extraSpeed;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
      
    }
}
