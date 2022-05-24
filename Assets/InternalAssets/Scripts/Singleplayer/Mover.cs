using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Mover : MonoBehaviour
    {
        private void Update()
        {
            transform.position -= new Vector3(0, 0, 0.667f * 12.356f * Time.deltaTime);
        }
    }
}