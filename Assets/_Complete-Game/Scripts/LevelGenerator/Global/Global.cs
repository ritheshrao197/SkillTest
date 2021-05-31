using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RogueTest
{
    public class Global : GenericSingletonClass<Global>
    {
        public static Action UpdateUI;
        internal  const string baseurl= "https://test-e3a53-default-rtdb.firebaseio.com/";
        [SerializeField]public static GameData gameData;
        public static int currentLevel = 1;
        public static string playerName = "Rithesh";
        internal static int maxFoodValue =200;

        private int food; 

        public int Food  
        {
            get { return food; }   
            set
            {
                food = value;
                UpdateUI();
            }  
        }
    }

}
