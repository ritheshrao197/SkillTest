using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

namespace RogueTest
{
    public class DataHandler : GenericSingletonClass<DataHandler>
    {

        private void Awake()
        {

            LoadResourceTextfile();
            foreach (Level level in Global.gameData.leveldata)
            {
                Debug.Log("levelNumber" + level.levelNumber);
                Debug.Log("columns" + level.columns);
                Debug.Log("rows" + level.rows);

            }

        }

        public static void LoadResourceTextfile()
        {

            string filePath = "GameData";//"SetupData/" + path.Replace(".json", "");

            TextAsset targetFile = Resources.Load<TextAsset>(filePath);
            Global.gameData = JsonConvert.DeserializeObject<GameData>(targetFile.text);
           
        }
        public static void WriteResourceTextfile(GameData gameData)
        {

#if UNITY_EDITOR
          string  path = "Assets/Resources/GameData.json";
#endif
            string data = JsonConvert.SerializeObject(gameData);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(data);
                }
            }
            ServerHandler.SaveGameDataToServer(data);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif


        }
    }

}
