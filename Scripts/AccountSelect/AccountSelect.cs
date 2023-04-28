using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AccountSelect : MonoBehaviour
{
    //new game button
    public void OnNewGame(){
        Debug.Log("New Game");
        DataManager.dataManager.newGame(); //create a new game.
        SceneManager.LoadSceneAsync("Menu"); //load into the game with a fresh game save
    }
    
    //load game button
    public void OnLoadGame(){
        Debug.Log("Load Game");
        SceneManager.LoadSceneAsync("Menu"); //load into the game with the saved game data


    }
}
