using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public abstract class GameInput : MonoBehaviour
    {
        public abstract RawInput GetRawInput();
    }
}