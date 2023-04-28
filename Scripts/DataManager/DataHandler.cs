using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataHandler 
{

    private string dataPath = ""; //path to the data file
    private string dataFile = ""; //name of the data file

    public DataHandler(string dataPath, string dataFile){
        this.dataPath = dataPath;
        this.dataFile = dataFile;
    }

    public PlayerData load(){

        //uses combine to account for different operating systems having different path separators
        string fullPathName = Path.Combine(dataPath, dataFile);
        PlayerData loadedPlayerData = null; //this will be the data that is loaded, initially null

        if (File.Exists(fullPathName)){ //if the file exists we can load it
            try{
                //this will load the serialized data from the file
                string loadedData = "";
                using(FileStream fs = new FileStream(fullPathName, FileMode.Open)){
                    using(StreamReader sr = new StreamReader(fs)){
                        loadedData = sr.ReadToEnd(); 
                    }
                }

                //now we have the serialized data, we can deserialize it
                loadedPlayerData = JsonUtility.FromJson<PlayerData>(loadedData); 

            }
            catch (Exception e){
                Debug.Log("Error loading data from: " + fullPathName + " !\n" + e); //if there is an error, we can log it
            }
        }
        return loadedPlayerData;  //return the loaded data
    }

    public void save(PlayerData gameData){

        //uses combine to account for different operating systems having different path separators
        string fullPathName = Path.Combine(dataPath, dataFile);

        try
        {
            //create file that will be written to if it doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPathName));

            //serialize the data into a json string
            string dataStore = JsonUtility.ToJson(gameData, true);

            // this will write the data to the file to be saved
            using(FileStream fs = new FileStream(fullPathName, FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(dataStore);
                }
            }


        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data to file " + fullPathName + " !\n" + e);
        }
    }
    
}
