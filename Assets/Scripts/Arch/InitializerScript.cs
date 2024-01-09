using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Arch
{
    class InitializerScript: MonoBehaviour
    {
        private InteractorsBase interactors;
        private void Awake()
        {
            interactors = new InteractorsBase();
            interactors.CreateAllInteractors();
            interactors.InitializeAllInteractors();
        }
    }
}
