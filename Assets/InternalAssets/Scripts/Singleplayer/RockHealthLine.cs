using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class RockHealthLine : MonoBehaviour
    {
        private const float mimDegree = -35f;
        private const float maxDegree = 35f;

        public void RotateToDegree(float degree)
        {
            transform.eulerAngles = new Vector3(0f, 0f, degree);
        }
    }
}