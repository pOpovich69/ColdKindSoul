using Assets.Scripts.Arch.Facades;
using Assets.Scripts.Arch.Repositories;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Arch.Interactors
{
    class LevelsInteractor : Interactor
    {
        public Dictionary<int, Level> Levels => levelsRepository.Levels;

        private LelvelsRepository levelsRepository;
        public LevelsInteractor()
        {
            levelsRepository = new LelvelsRepository();
            levelsRepository.Initialize();
        }
        public override void Initialize()
        {
            CreateAllLevels();
            LevelsFacade.Initialize(this);
        }
        public Level GetLevelWithId(int id)
        {
            var levelKeys = Levels.Keys.ToList();

            if (levelKeys.Contains(id))
                return Levels[id];
            else
                return null;
        }
        public bool NextWave(int levelId)
        {
            Level level = GetLevelWithId(levelId);

            if (level.CurrentWave < level.MaxWaves)
            {
                level.CurrentWave++;
                return true;
            }
            else
            {
                return false;
            }

        }
        public void SetAsDone(int levelId)
        {
            Level level = GetLevelWithId(levelId);

            level.IsDone = true;
            levelsRepository.Save();
        }
        public void SetStars(int levelId, int stars)
        {
            Level level = GetLevelWithId(levelId);

            if (stars > 3)
            {
                level.Stars = 3;
            }
            else if (stars <= 1)
            {
                level.Stars = 1;
            }
            else
            {
                level.Stars = stars;
            }
            levelsRepository.Save();
        }
        public void SetTime(int levelId, string timeInString)
        {
            Level level = GetLevelWithId(levelId);

            level.Time = timeInString;
            levelsRepository.Save();
        }

        public void SetLevelsByDefault()
        {
            levelsRepository.SaveByDefault();
        }

        private void CreateAllLevels()
        {
            CreateLevel(new Level(1, 3));
            CreateLevel(new Level(2, 2));
            CreateLevel(new Level(3, 2));
        }
        private void CreateLevel(Level level)
        {
            var levelKeys = Levels.Keys.ToList();
            if (levelKeys.Contains(level.LevelId))
                return;

            levelsRepository.Levels[level.LevelId] = level;
            levelsRepository.Save();
        }

    }
}
