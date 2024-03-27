using Assets.Scripts.DataSave.Data;
using Assets.Scripts.Gameplay.LevelScripts.LevelLogic;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Arch.Repositories
{
    class LelvelsRepository : IRepository
    {
        public Dictionary<int, Level> Levels;

        private Storage storage;
        private LevelsData playerData;
        public void Initialize()
        {
            storage = new Storage("LevelsData");
            playerData = (LevelsData)storage.Load(new LevelsData());
            Levels = playerData.Levels;
        }
        public void Save()
        {
            playerData.Levels = Levels;
            storage.Save(playerData);
        }
    }
}
