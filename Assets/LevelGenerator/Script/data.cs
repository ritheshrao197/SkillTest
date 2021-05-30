using System.Collections.Generic;
using UnityEngine;
namespace RogueTest
{
    public enum CellType
    {
        start,
        floor,
        wall1,
        wall2,
        wall3,
        wall4,
        enemy1,
        enemy2,
        food,
        cola,
        exit
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PlayerData
    {
        public int restartLevelDelay { get; set; }
        public int pointsPerFood { get; set; }
        public int pointsPerSoda { get; set; }
        public int wallDamage { get; set; }
    }

    public class CellData
    {
        public int x { get; set; }
        public int y { get; set; }
        public int cellType { get; set; }

        public void SetCellData(int x,int y,int type)
        {
            this.x = x;
            this.y = y;
            cellType = type;
        }
    }

    public class Level
    {
        public int levelNumber { get; set; }
        public int enemyCount { get; set; }
        public int columns { get; set; }
        public int rows { get; set; }
        public List<CellData> cells { get; set; }
    }

    public class WallData
    {
        public int hp { get; set; }
    }

    public class GameData
    {
        public int levels { get; set; }
        public float levelStartDelay { get; set; }
        public float turnDelay { get; set; }
        public int playerFoodPoints { get; set; }
        public PlayerData playerData { get; set; }
        public List<Level> leveldata { get; set; }
        public WallData wallData { get; set; }
    }

    public class Root
    {
        public GameData GameData { get; set; }
    }




}