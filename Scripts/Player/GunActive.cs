using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunActive : MonoBehaviour, DataSaveLoad
{
    [Header("Gun Active")]
    private int gunActive;
    public GameObject pistol;
    public GameObject SMG;
    

    //When the level starts it checks which gun is active.
    void Start()
    {
         if (gunActive == 0){ //if not upgraded yet then use the pistol
            pistol.SetActive(true);
            SMG.SetActive(false);
        } else if (gunActive == 1){ //if upgraded then use the SMG
            pistol.SetActive(false);
            SMG.SetActive(true);
        }
    }

    //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
        this.gunActive += gameData.gunActive;
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
      
    }
}
