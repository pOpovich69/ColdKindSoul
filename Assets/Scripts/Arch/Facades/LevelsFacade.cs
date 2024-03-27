using Assets.Scripts.Arch.Interactors;
using Assets.Scripts.Arch.Repositories;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
