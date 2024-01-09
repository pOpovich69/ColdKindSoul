using Assets.Scripts.DataSave.Data;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Arch.Repositories
{
    class PlayerRepository : IRepository
    {


        private Storage storage;
        private PlayerData playerData;
        public void Initialize()
        {
            storage = new Storage("PlayerData");
            playerData = (PlayerData)storage.Load(new PlayerData());

        }
        public void Save()
        {

            storage.Save(playerData);
        }
    }
}
