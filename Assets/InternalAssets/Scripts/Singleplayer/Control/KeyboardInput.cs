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
                PressNotes = new bool[5]
                {
                    Input.GetKey(KeyCode.Z),
                    Input.GetKey(KeyCode.X),
                    Input.GetKey(KeyCode.C),
                    Input.GetKey(KeyCode.V),
                    Input.GetKey(KeyCode.B)
                },

                ReleaseNotes = new bool[5]
                {
                    Input.GetKeyUp(KeyCode.Z),
                    Input.GetKeyUp(KeyCode.X),
                    Input.GetKeyUp(KeyCode.C),
                    Input.GetKeyUp(KeyCode.V),
                    Input.GetKeyUp(KeyCode.B)
                }
            };
        }
    }
}