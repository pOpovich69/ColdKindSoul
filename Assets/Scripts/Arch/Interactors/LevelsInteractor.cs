using Assets.Scripts.Arch.Facades;
using Assets.Scripts.Arch.Repositories;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void CreateAllLevels()
        {
            CreateLevel(new Level(1, 3));
            CreateLevel(new Level(2, 3));
            CreateLevel(new Level(3, 3));
            CreateLevel(new Level(4, 3));
            CreateLevel(new Level(5, 3));
        }
        public Level GetLevelWithId(int id)
        {
            var levelKeys = Levels.Keys.ToList();

            if (levelKeys.Contains(id))
                return Levels[id];
            else
                return null;
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
