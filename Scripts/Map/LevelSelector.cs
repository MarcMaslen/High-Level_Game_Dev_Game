using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    // load level 1
    public void Level1(){
        Debug.Log("Level 1");
        SceneManager.LoadScene("LevelOne");
    }

    // load level 2
    public void Level2(){
        Debug.Log("Level 2");
        SceneManager.LoadScene("LevelTwo");
    }

    // load main menu
    public void Menu(){
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
}
