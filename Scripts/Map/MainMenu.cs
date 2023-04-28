using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, DataSaveLoad
{

    private float musicLevel; //holds music level value
    public float brightness; //music level
    public Image background; //background image
    private int level;
    public Text levelText;

    //When the scene is loaded we will put the slider value to the music level
    void Update(){
        AudioListener.volume = musicLevel;
        levelText.text = "Level:" + level.ToString();
        ChangeAlpha(brightness); //change alpha
    }

    //allows the user to change the brightness by changing the alpha of the overlay. 
    public void ChangeAlpha(float alpha){
        background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);
    }

    //This will load the level select screen
    public void PlayGame(){
        Debug.Log("Play");
        SceneManager.LoadScene("LevelSelect");
    }

    //this will load the settings menu
    public void Settings(){
        Debug.Log("Settings");
        SceneManager.LoadScene("Settings");
    }

    //this will quit the application 
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    //here we load the data in from player data and set it to the music level
     public void loadData(PlayerData gameData){
        this.musicLevel = gameData.musicLevel;
        this.level = gameData.permLevel;
        this.brightness = gameData.brightness;
    }

    //here we save the data in from music level and save it to player data for next save
    //NOTE: This is not used in this script but is needed for the interface
    public void saveData(PlayerData gameData){}

}
