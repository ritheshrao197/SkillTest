using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace RogueTest
{
    public class LevelDataGenerator : MonoBehaviour
    {
        [SerializeField] TMP_InputField TotalNumberOfLevels;
        [SerializeField] TMP_InputField LevelStartDelay;
        [SerializeField] TMP_InputField turnDelay;
        [SerializeField] TMP_InputField playerFoodPoints;
        [SerializeField] TMP_InputField RestartLevelDelay;
        [SerializeField] TMP_InputField pointsPerFood;
        [SerializeField] TMP_InputField pointsPerSoda;
        [SerializeField] TMP_InputField wallDamage;
        [SerializeField] TMP_Dropdown levelNumber;
      //  [SerializeField] TMP_InputField enemyCount;
        [SerializeField] TMP_InputField columns;
        [SerializeField] TMP_InputField rows;
        [SerializeField] TMP_InputField hp;

        [SerializeField] GameObject cell;
        [SerializeField] Transform gridParent;
        [SerializeField] List<Cell> cells = new List<Cell>();
        GameData gameData = new GameData();

         Level level = new Level();
        private void Start()
        {
            LoadData();
        }
        // Start is called before the first frame update
        void LoadData()
        {
            Debug.Log("Log dataa");
            gameData = Global.gameData;
            Displaydata();
        }
        public void Displaydata()
        {
            Debug.Log("Displaydata");

            TotalNumberOfLevels.text = gameData.levels.ToString();
            LevelStartDelay.text = gameData.levelStartDelay.ToString();
            turnDelay.text = gameData.turnDelay.ToString();
            playerFoodPoints.text = gameData.playerFoodPoints.ToString();
            RestartLevelDelay.text = gameData.playerData.restartLevelDelay.ToString();
            pointsPerFood.text = gameData.playerData.pointsPerFood.ToString();
            pointsPerSoda.text = gameData.playerData.pointsPerSoda.ToString();
            wallDamage.text = gameData.playerData.wallDamage.ToString();
            hp.text = gameData.wallData.hp.ToString();
            levelNumber.ClearOptions();
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            for (int i = 1; i <= gameData.levels; i++)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(i.ToString());
                options.Add(option);
            }
            levelNumber.AddOptions(options);
            levelNumber.value = gameData.leveldata[0].levelNumber;

        }


        private void ShowLeveldata(int levelnumber)
        {
            level = gameData.leveldata[levelnumber];

          

         //   enemyCount.text = gameData.leveldata[levelnumber].enemyCount.ToString();
            columns.text = gameData.leveldata[levelnumber].columns.ToString();
            rows.text = gameData.leveldata[levelnumber].rows.ToString();
            CreateGrid();
           
            foreach (Cell cell in cells)
                foreach (CellData celldata in gameData.leveldata[levelnumber].cells)
                if (cell.x == celldata.x && cell.y == celldata.y)
                {
                        cell.SetCellType(celldata.cellType);
                }

            

        }

        public void CreateGrid()
        {
            updategamedata();

          //  level.levelNumber = (levelNumber.value+1);
         //   level.enemyCount = int.Parse(enemyCount.text);
            //level.columns = int.Parse(columns.text);
            //level.rows = int.Parse(rows.text);

            cells.Clear();
            ClearParent(gridParent.transform);
            gridParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(gridParent.GetComponent<RectTransform>().rect.width / float.Parse(rows.text),
                gridParent.GetComponent<RectTransform>().rect.height / float.Parse(columns.text));
            for (int i = 0; i < level.rows; i++)
            {
                for (int j = 0; j < level.columns; j++)
                {
                    GameObject go = Instantiate(cell, gridParent);
                    go.GetComponent<Cell>().SetPosition(i, j);
                    cells.Add(go.GetComponent<Cell>());
                }
            }
        }

        private void updategamedata()
        {
            gameData.levels = int.Parse(TotalNumberOfLevels.text);
            gameData.levelStartDelay = float.Parse(LevelStartDelay.text);
            gameData.playerFoodPoints = int.Parse(playerFoodPoints.text);
            gameData.playerData.restartLevelDelay = int.Parse(RestartLevelDelay.text);
            gameData.playerData.pointsPerFood = int.Parse(pointsPerFood.text);
            gameData.playerData.pointsPerSoda = int.Parse(pointsPerSoda.text);
            gameData.playerData.wallDamage = int.Parse(wallDamage.text);
        }
        public void SaveLevelData()
        {
            level.levelNumber = levelNumber.value + 1;
            level.columns = int.Parse(columns.text);
            level.rows = int.Parse(rows.text);
            List<CellData> newCells = new List<CellData>();
            level.enemyCount = 0;
            foreach(Cell cell in cells)
            {
                //if(cell.cellType!=CellType.floor)
                {
                    CellData cellData = new CellData();
                    cellData.SetCellData(cell.x, cell.y, (int)cell.cellType);
                    newCells.Add(cellData);
                    if (cell.cellType == CellType.enemy1 || cell.cellType == CellType.enemy2)
                    {
                        level.enemyCount++;
                    }
                }
               
            }
            level.cells = newCells;
            gameData.leveldata[level.levelNumber-1] =level;

        }
        public static void ClearParent(Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            };
        }
        public void Save()
        {
            SaveLevelData();
            DataHandler.WriteResourceTextfile(gameData);
        }
        public void OnLevelDataChanged()
        {
            Debug.Log("LevelNumber " + levelNumber.value);
            if (level.levelNumber != levelNumber.value + 1)
                ShowLeveldata(levelNumber.value);
        }
        public void OnTotalNumberOfLevelsValueChanged()
        {
            int newlevelcount = int.Parse(TotalNumberOfLevels.text);
            int levelDiff = newlevelcount - gameData.levels;
            List<string> m_DropOptions = new List<string> ();

            if (levelDiff>0)
            {
                List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

                for (int i=0;i<levelDiff; i++)
                {
                    Level newlevel = gameData.leveldata[gameData.levels - 1];
                    gameData.levels++;
                    newlevel.levelNumber = gameData.levels;

                    gameData.leveldata.Add(newlevel);
                    m_DropOptions.Add(newlevel.levelNumber.ToString());
                    TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(newlevel.levelNumber.ToString());
                    options.Add(option);

                }
               
                levelNumber.AddOptions(options);
            }
            else
            {
                TotalNumberOfLevels.text = gameData.levels.ToString();
            }
        }

    }
}