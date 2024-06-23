using Assets.Scripts.Arch.Interactors;
using Assets.Scripts.Arch.Repositories;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using System.Collections.Generic;

namespace Assets.Scripts.Arch.Facades
{
    static class LevelsFacade
    {
        public static Dictionary<int, Level> Levels => interactor.Levels;

        private static LevelsInteractor interactor;
        public static void Initialize(LevelsInteractor levelsInteractor)
        {
            interactor = levelsInteractor;
        }
        public static Level GetLevelWithId(int id)
        {
            return interactor.GetLevelWithId(id);
        }
        public static bool NextWave(int levelId)
        {
            return interactor.NextWave(levelId);
        }
        public static void SetAsDone(int levelId)
        {
            interactor.SetAsDone(levelId);
        }
        public static void SetStars(int levelId, int stars)
        {
            interactor.SetStars(levelId, stars);
        }
        public static void SetTime(int levelId, string timeInString)
        {
            interactor.SetTime(levelId, timeInString);
        }

        public static void SetLevelsByDefault()
        {
            interactor.SetLevelsByDefault();
        }
    }
}
