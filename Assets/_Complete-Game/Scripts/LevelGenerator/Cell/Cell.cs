using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
namespace RogueTest
{
    public class Cell : MonoBehaviour
    {
        public int x;
        public int y;
        public CellType cellType = CellType.floor;
        public TMP_Dropdown dropdown;



        public void OnValueChange()
        {
            switch(dropdown.options[dropdown.value].text)
            {
                case "":
                    break;
            }
            cellType = (CellType)dropdown.value;
            Debug.Log(cellType.ToString());
        }
        /// <summary>
        /// Sets the position of Grid
        /// </summary>
        /// <param name="x">row</param>
        /// <param name="y">col</param>
        internal void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            cellType = CellType.floor;
            dropdown.value = (int)cellType;

        }
        /// <summary>
        /// Sets cell Type
        /// </summary>
        /// <param name="type"></param>
        internal void SetCellType(int type)
        {
            dropdown.value = type;
        }
    }
}
