using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.DataSave.Data
{
    [Serializable]
    public class LevelsData
    {
        public Dictionary<int, Level> Levels;

        //Стандартные значения
        public LevelsData()
        {
            Levels = new Dictionary<int, Level>();
        }
    }
}
