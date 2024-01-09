using Assets.Scripts.Arch.Facades;
using Assets.Scripts.Arch.Repositories;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Arch.Interactors
{
    class PlayerInteractor : Interactor
    {

        private PlayerRepository playerRepository;

        public PlayerInteractor()
        {
            playerRepository = new PlayerRepository();
            playerRepository.Initialize();
        }

        public override void Initialize()
        {
            PlayerFacade.Initialize(this);
        }
    }
}

