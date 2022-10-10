using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public struct ServiceInput
    {
        public bool IsPausePressed { get; }

        public ServiceInput(bool isPausePressed)
        {
            IsPausePressed = isPausePressed;
        }
    }
}