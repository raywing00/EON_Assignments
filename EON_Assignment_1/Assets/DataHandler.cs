using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EON_Quiz
{
    

    public class DataHandler : MonoBehaviour
    {

        string data_json;  // JSON representation
        string json_path = "";  // JSON Data path

        private class QuizData
        {
            public int quizListLength;
        }


        void Start()
        {
            SetJSONDataPath();


            LoadData();
            


            QuizData quizData = new QuizData();
            
            Debug.Log("Current length is " + quizData.quizListLength);

            quizData.quizListLength += 1;

            Debug.Log("New length is " + quizData.quizListLength);




            data_json = JsonUtility.ToJson(quizData);

            // LEARNING NOTES
            // .ToJson : "Generate a JSON representation of the public fields of an object"
            // 'data_json' is the 'JSON representation' of playerData, which holds the public fields
            // Data is converted into a JSON here
            Debug.Log(data_json); // Display JSON representation data 


            SaveData();
            


            //QuizData loadedQuizData = JsonUtility.FromJson<QuizData>(data_json);
            // LEARNING NOTES
            // .FromJson : "Create an object from its JSON representation"
            // Create 'loadedPlayerData' (object), from 'data_json' ('JSON representation')
            // Data is extracted from a JSON here
            //Debug.Log("Loading Data File");
            

        }




        private void SetJSONDataPath()
        {
            json_path = Application.dataPath + "/dataFile.json";
            
            //json_path = Application.persistentDataPath + "/dataFile.json";   
            // Use Persistent Path for actual production

        }

        public void SaveData()
        {
            // Saving the JSON data to save save file "saveFile.json"
            // v Command      v path                  v file name      v JSON representation
            File.WriteAllText(json_path, data_json);

        }

        public void LoadData()
        {
            // Loading the JSON data from save file "saveFile.json"


            if (System.IO.File.Exists(json_path))
            {
                Debug.Log("File found!");
                data_json = File.ReadAllText(json_path);

                QuizData loadedQuizData = JsonUtility.FromJson<QuizData>(data_json);
                // LEARNING NOTES
                // .FromJson : "Create an object from its JSON representation"
                // Create 'loadedPlayerData' (object), from 'data_json' ('JSON representation')
                // Data is extracted from a JSON here
                //Debug.Log("Loading Data File");

                // How to pump data back to main?
            }
            else Debug.Log("File NOT found!");

        }

    }
}