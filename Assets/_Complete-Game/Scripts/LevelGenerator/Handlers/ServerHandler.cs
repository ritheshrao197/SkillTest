using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using RogueTest;
using System;
namespace RogueTest
{
    public class Score
        {
        public string name;
        public int score;

        public Score(string v1, int v2)
        {
            name = v1;
            score = v2;
        }
    }
    public class ServerHandler : MonoBehaviour
    {

        //public static Action OnDataRetrieved;
        //private void Awake()
        //{
        //    RetrieveFromDatabase();
        //}

        // Start is called before the first frame update
        private void Start()
        {
            SaveHighScoreToServer();
        }
        public static void SaveGameDataToServer(string gameData)
        {
            
            Debug.Log("Data" + gameData);
            RestClient.Put("https://test-e3a53-default-rtdb.firebaseio.com/gameData.json", gameData);
        }

        public static void SaveHighScoreToServer()
        {
            Score s1 = new Score("Rithesh", UnityEngine.Random.Range(10, 200));
            Score s2 = new Score("Nithesh", UnityEngine.Random.Range(10, 200));
            Score s3 = new Score("Arjun", UnityEngine.Random.Range(10, 200));
            Score s4 = new Score("Aryan", UnityEngine.Random.Range(10, 200));


            RestClient.Put("https://test-e3a53-default-rtdb.firebaseio.com/HighScore/"+s1.name+".json", s1.score.ToString());
            RestClient.Put("https://test-e3a53-default-rtdb.firebaseio.com/HighScore/"+s2.name+".json", s2.score.ToString());
            RestClient.Put("https://test-e3a53-default-rtdb.firebaseio.com/HighScore/"+s3.name+".json", s3.score.ToString());
            RestClient.Put("https://test-e3a53-default-rtdb.firebaseio.com/HighScore/"+s4.name+".json", s4.score.ToString());
        }                                                                                        
        public void getHighscores()
        {
            RestClient.Get("https://test-e3a53-default-rtdb.firebaseio.com/HighScore.json").Then(response =>
            {
                Debug.Log("Dataretrieved " + response.ToString());


            });
        }
        public void RetrieveFromDatabase()
        {
            RestClient.Get<GameData>("https://test-e3a53-default-rtdb.firebaseio.com/gameData.json").Then(response =>
            {
                Debug.Log("Dataretrieved " + response.ToString());
            //    Global.gameData = response;
            //if(OnDataRetrieved!=null)
            //{
            //    OnDataRetrieved();
            //    Debug.Log("Dataretrieved");

            //}

        });
        }

    }
}