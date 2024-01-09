using Assets.Scripts.Arch.Interactors;

namespace Assets.Scripts.Arch.Facades
{
    static class PlayerFacade
    {
        private static PlayerInteractor interactor;

        public static void Initialize(PlayerInteractor playerInteractor)
        {
            interactor = playerInteractor;
        }

    }
}
