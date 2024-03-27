using Assets.Scripts.Arch.Interactors;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Arch
{
    class InteractorsBase
    {
        private List<Interactor> interactors;
        public InteractorsBase()
        {
            interactors = new List<Interactor>();
        }
        public void CreateAllInteractors()
        {
            CreateInteractor<LevelsInteractor>();
            CreateInteractor<PlayerInteractor>();
        }
        public void InitializeAllInteractors()
        {
            foreach (Interactor interactor in interactors) 
                interactor.Initialize(); 
        }
        private void CreateInteractor<T>() where T : Interactor, new()
        {
            interactors.Add(new T());
        }
    }
}
