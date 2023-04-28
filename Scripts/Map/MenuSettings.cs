using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MenuSettings : MonoBehaviour, DataSaveLoad
{

    [Header("Menu Settings")]
    public Slider musicSlider; //volume slider
    public float musicLevel; //music level
    public Slider brightnessSlider; //volume slider
    public float brightness; //music level
    public Image background; //background image

    //When the scene is loaded we will put the slider value to the music level
    void Start(){
        musicSlider.value = musicLevel;
        brightnessSlider.value = brightness;
    }

    //When the user changes the slider value we will change the music level and the audio listen volume
    void Update(){
        musicLevel = musicSlider.value; //music volume level
        AudioListener.volume = musicLevel; //audio listener volume

        brightness = brightnessSlider.value; //brightness level
        ChangeAlpha(brightness); //change alpha
    }

    public void ChangeAlpha(float alpha){
        background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);
    }

    //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.musicLevel = gameData.musicLevel;
        this.brightness = gameData.brightness;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
        gameData.musicLevel = this.musicLevel;
        gameData.brightness = this.brightness;
    }
}
