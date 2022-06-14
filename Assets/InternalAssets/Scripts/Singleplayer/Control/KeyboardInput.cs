using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class KeyboardInput : GameInput
    {
        public override InputData GetInput()
        {
            return new InputData
            {
                Notes = new bool[5]
                {
                    Input.GetKeyDown(KeyCode.Z),
                    Input.GetKeyDown(KeyCode.X),
                    Input.GetKeyDown(KeyCode.C),
                    Input.GetKeyDown(KeyCode.V),
                    Input.GetKeyDown(KeyCode.B)
                }
            };
        }
    }
}