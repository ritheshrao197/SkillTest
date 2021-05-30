using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RogueTest
{
    public class Global : GenericSingletonClass<Global>
    {
        [SerializeField]public static GameData gameData;
        public static int currentLevel = 1;
        public static string playerName = "Rithesh";

    }

}
