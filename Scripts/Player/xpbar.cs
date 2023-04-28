using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpbar : MonoBehaviour, DataSaveLoad
{
    [Header("XP Bar")]
    public Slider slider; //xp bar slider
    public Text LevelText; //level text
    private AudioSource audioSource;

    [Header("XP stats")]
    public int MaxXP = 15; //max xp for level
    public int CurrentXP; //holds current xp
    public int startXP = 0; //start xp
    public bool isLevelUp = false; //checks if level up
    public int Level = 0; //level
    public int level = 0; //level for skill points
    public int skillPoint = 0; //skill points
    private GameMaster GameMaster;
    private PermUpgrades PU;


    //Sets XP to 0 on start 
    void Start(){
        CurrentXP = startXP; //sets current xp to start xp
        setXP(CurrentXP); //sets xp bar to current xp
        audioSource = GetComponent<AudioSource>(); 
        GameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    //this constantly updates level on screen
    //when current xp is equal to mapXP it will level the player up and reset back to 0
    void Update(){
        SetLevel(); //sets level text
        GainXP(GameMaster.xp); //gains xp from game master
        if (CurrentXP >= MaxXP){ //if current xp is greater than max xp
            LevelUp(); //level up
        } else {
            isLevelUp = false; //if not level up is false
        }

        if (level == 2){ //if level is 2
            skillPoint += 1; //add 1 skill point
            level = 0;   //reset level
        }
        
    }

    //sets slider value to the amount of xp gained
    public void setXP(int xp){
        slider.value = xp;
    }

    //gains xp when a zombie is killed
    void GainXP(int xp){
        CurrentXP = xp;
        setXP(CurrentXP);
    }

    //sets level text
     public void SetLevel(){
        LevelText.text = "Level: " + Level.ToString();
    }

    //levels up the player
    public void LevelUp(){
        isLevelUp = true; //level up is true
        Level += 1; 
        level += 1;
        slider.maxValue += 1;
        MaxXP += 1; //max xp goes up by 1 to make it harder to level up each time
        CurrentXP = 0; //current xp goes back to 0
        GameMaster.xp = 0; //game master xp goes back to 0
        audioSource.Play();
        Debug.Log("Level Up");
    }

     //here we load the data in from player data and set it to the music level
    public void loadData(PlayerData gameData){
    }

    //here we save the data in from music level and save it to player data for next save
    public void saveData(PlayerData gameData){
         gameData.skillPoints += this.skillPoint;
    }
 

}
