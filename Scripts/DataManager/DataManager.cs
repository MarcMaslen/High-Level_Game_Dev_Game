using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("Data file config")]
    [SerializeField] private string dataFileName;

    public static DataManager dataManager {get; private set;} //can only modify this privately within this class
    private PlayerData data;
    private List<DataSaveLoad> dataManagerList;
    private DataHandler dataHandler;

    //this means only one data persistence object can exist at a time
    private void Awake(){
        if (dataManager != null){
            Debug.Log("dataManager already exists");
            Destroy(this.gameObject);
            return;
        }
        dataManager = this;
        this.dataHandler = new DataHandler(Application.persistentDataPath, dataFileName);
        DontDestroyOnLoad(this.gameObject);
    }

    //Both onEnable and onDisable are called when the object is enabled or disabled, this needs to be done before the start method
    public void OnEnable(){
        SceneManager.sceneLoaded += sceneOpened; //when a scene is loaded, call the sceneOpened method
        SceneManager.sceneUnloaded += sceneClosed; //when a scene is closed, call the sceneClosed method
    }

    public void OnDisable(){
        SceneManager.sceneLoaded -= sceneOpened; //when a scene is loaded, call the sceneOpened method
        SceneManager.sceneUnloaded -= sceneClosed; //when a scene is closed, call the sceneClosed method
    }
    
    //when a scene is opened, we can load the data that is needed for that specific scene
    public void sceneOpened(Scene scene, LoadSceneMode load){
        Debug.Log("Scene opened: " + scene.name); //display log of scene name

        //When scene is opened we can check the data and load the game
        this.dataManagerList = FindAlldataManagerItems();
        loadGame();
    }
    

    //when the scene is closed we will display a log and save the game. 
    public void sceneClosed(Scene scene){
        Debug.Log("Scene closed: " + scene.name);
        saveGame();
    }

    // The start method has the log to show you the file path for the data file on your PC
    //I thought this might be good to add while marking so you can check the file yourself, open in text file for easy reading
    private void Start(){
        Debug.Log("DataHandler created " + Application.persistentDataPath);
    }

    //sets up new game so the player can start again with a fresh save
    public void newGame(){
        this.data = new PlayerData();
    }

    //saves the game data into the data file, this is called right after new game to automatically save the game data
    public void saveGame(){

        //save data to each data persistence item
        foreach (DataSaveLoad dataManager in dataManagerList){
            dataManager.saveData(data);
        }

        //keep log on what is changed
        Debug.Log("Music Level: " + this.data.musicLevel);

        //save the data using the data handler
        dataHandler.save(data);

    }

    public void loadGame(){

        //load the data from the file using the data handler
        this.data = dataHandler.load();

        //if no data file exists, we will create a new one
        if (this.data == null){
            Debug.Log("No data found, creating new game");
            newGame();
        }

        //if data file exists, we will load it to all scripts that implement I_DataManager
        foreach (DataSaveLoad dataManager in dataManagerList){
            dataManager.loadData(data);
        }

        Debug.Log("Music Level: " + this.data.musicLevel);
        Debug.Log("Game loaded");

    }

    //When ever the application is closed it will auto save the game.
    private void OnApplicationQuit(){
        saveGame();
    }

    private List<DataSaveLoad> FindAlldataManagerItems(){
        //This line finds all scripts ending in I_dataManager and puts them in a list, but must have monobehaviour
        IEnumerable<DataSaveLoad> dataManagerItems = FindObjectsOfType<MonoBehaviour>().OfType<DataSaveLoad>();
        return new List<DataSaveLoad>(dataManagerItems);
    }
}
