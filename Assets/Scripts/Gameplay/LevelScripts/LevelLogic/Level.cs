using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Gameplay.LevelScripts.LevelLogic
{
    [Serializable]
    public class Level
    {
        public int LevelId { get; private set; }
        public int MaxWaves { get; private set; }
        public int StartPoints { get; private set; }

        public int CurrentWave { get; set; }
        public int PointInCurrentWave => CalculatePointsAtWave();

        public bool IsDone { get; set; }

        public int Stars { get; set; }

        public int Time {  get; set; }

        public Level(int levelId, int maxWaves) 
        {
            LevelId = levelId;
            MaxWaves = maxWaves;

            if (levelId > 0)
                StartPoints = levelId;
            else 
                StartPoints = 1;
        }
        private int CalculatePointsAtWave()
        {
            return CurrentWave * StartPoints;
        }

        public static implicit operator Level(KeyValuePair<int, Level> v)
        {
            throw new NotImplementedException();
        }
    }
}
