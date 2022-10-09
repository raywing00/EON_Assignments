using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public string json_1;  // JSON representation
    public string json_2;  // JSON representation
    public string json_3;  // JSON representation
    public string path = "";  // Data path
    public string persistentPath = "";  // Persistent Data path



    void Start()
    {
        SetDataPaths();

        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(5, 0);
        playerData.health = 75;


        json_1 = JsonUtility.ToJson(playerData);
        json_2 = JsonUtility.ToJson(playerData);
        json_3 = JsonUtility.ToJson(playerData);
        // LEARNING NOTES
        // .ToJson : "Generate a JSON representation of the public fields of an object"
        // 'json' is the 'JSON representation' of playerData, which holds the public fields
        // Data is converted into a JSON here
        Debug.Log(json_1); // Display JSON representation data 



        SaveData();
        LoadData();


        /*
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        File.WriteAllText(path, json);
        File.WriteAllText(persistentPath, json);
        */

        /*
        // Loading the JSON data from save file "saveFile.json"
        json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        */


        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json_1);
        // LEARNING NOTES
        // .FromJson : "Create an object from its JSON representation"
        // Create 'loadedPlayerData' (object), from 'json' ('JSON representation')
        // Data is extracted from a JSON here
        Debug.Log("Json file 1");
        Debug.Log("Position : " + loadedPlayerData.position);
        Debug.Log("Health : " + loadedPlayerData.health);




    }


    // Create a Class to store the data to save, to be parse into JSON and save to a file 
    private class PlayerData
    {
        public Vector3 position;
        public int health;
    }


    private void SetDataPaths()
    {
        path = Application.dataPath + "/saveFile_2.json";
        persistentPath = Application.dataPath + "/saveFile_3.json";   // Use Persistent Path for actual production

    }

    public void SaveData()
    {
        // Saving the JSON data to save save file "saveFile.json"
        // v Command      v path                  v file name      v JSON representation
        File.WriteAllText(Application.dataPath + "/saveFile_1.json", json_1);
        File.WriteAllText(path, json_2);
        File.WriteAllText(persistentPath, json_3);
    }

    public void LoadData()
    {
        // Loading the JSON data from save file "saveFile.json"
        json_1 = File.ReadAllText(Application.dataPath + "/saveFile_1.json");
        json_2 = File.ReadAllText(Application.dataPath + "/saveFile_2.json");
        json_3 = File.ReadAllText(Application.dataPath + "/saveFile_3.json");


    }


}
