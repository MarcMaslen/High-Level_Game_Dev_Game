using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused;
    public GameObject pauseMenu;
    public GameObject MainPlayer;
    public GameObject Gun;

    //Sets menu to false when scene is loaded
    void Start()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
    }

    // when escape key is pressed called menu or continues game
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gamePaused){
                PlayGame();
                AudioListener.pause = false;
            } else {
                PauseGame();
                AudioListener.pause = true;
            }
        }
    }

    //Play game method, enabled player movement and shooting as well as sets time scale back
    public void PlayGame(){
        gamePaused = false;
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    //Pauses time and disables player movement and shooting.
    public void PauseGame(){
        gamePaused = true;
        pauseMenu.SetActive(true);
        MainPlayer.GetComponent<Player_movement>().enabled = false;
        Gun.GetComponent<shooting>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    //Restarts the game and enables player movement and shooting.
    public void RestartGame(){
        Time.timeScale = 1;
        AudioListener.pause = false;
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Loads the menu and enables player movement and shooting.
    public void Menu(){
        Time.timeScale = 1;
        AudioListener.pause = false;
        MainPlayer.GetComponent<Player_movement>().enabled = true;
        Gun.GetComponent<shooting>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
