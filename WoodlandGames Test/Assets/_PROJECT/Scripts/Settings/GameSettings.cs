using System.Collections;
using System.Collections.Generic;
using _PROJECT.Scripts.Data;
using UnityEngine;
using UnityEngine.UIElements;

namespace _PROJECT.Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/SpawnManagerScriptableObject")]
    public class GameSettings : ScriptableObject
    {
        public List<Level> levels = new List<Level>();

        public Level GetLevel(ELevel level)
        {
            return levels[(int)level];
        }
        
    }
}