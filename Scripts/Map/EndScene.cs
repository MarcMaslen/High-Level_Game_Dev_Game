using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    //gets the game object for the end game scene
    public GameObject gameEndScene; 
    public GameObject MainPlayer;
    public GameObject Gun;
    private Health Health;

    //Sets end game scene to false when scene is loaded
    void Start()
    {
        gameEndScene.SetActive(false); //set it to false when the scene is loaded
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        
    }

    // when escape key is pressed called menu or continues game
    void Update()
    {
        if (Health.health == 0){ //if health is 0 then end game
            EndGame();
        }
    }

    //End game and disables player movement and shooting.
    public void EndGame(){
        gameEndScene.SetActive(true);
        MainPlayer.GetComponent<Player_movement>().enabled = false;
        Gun.GetComponent<shooting>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Over");
        AudioListener.pause = false;
    }

    //Restarts the game and enables player movement and shooting.
    public void RestartGame(){
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Loads the menu and enables player movement and shooting.
    public void Menu(){
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
