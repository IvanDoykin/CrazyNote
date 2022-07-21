using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class KeyboardInput : GameInput
    {
        public override RawInput GetRawInput()
        {
            return new RawInput
            (
                new bool[5]
                {
                    UnityEngine.Input.GetKeyDown(KeyCode.Z),
                    UnityEngine.Input.GetKeyDown(KeyCode.X),
                    UnityEngine.Input.GetKeyDown(KeyCode.C),
                    UnityEngine.Input.GetKeyDown(KeyCode.V),
                    UnityEngine.Input.GetKeyDown(KeyCode.B)
                },

                new bool[5]
                {
                    UnityEngine.Input.GetKey(KeyCode.Z),
                    UnityEngine.Input.GetKey(KeyCode.X),
                    UnityEngine.Input.GetKey(KeyCode.C),
                    UnityEngine.Input.GetKey(KeyCode.V),
                    UnityEngine.Input.GetKey(KeyCode.B)
                },

                new bool[5]
                {
                    UnityEngine.Input.GetKeyUp(KeyCode.Z),
                    UnityEngine.Input.GetKeyUp(KeyCode.X),
                    UnityEngine.Input.GetKeyUp(KeyCode.C),
                    UnityEngine.Input.GetKeyUp(KeyCode.V),
                    UnityEngine.Input.GetKeyUp(KeyCode.B)
                }
            );
        }
    }
}