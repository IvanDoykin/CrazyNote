using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class Mover : MonoBehaviour
    {
        private float _clock = 0f;

        private void Update()
        {
            transform.position -= new Vector3(0, 0, 0.45f * 13.9f * Time.deltaTime);
        }

        private void LateUpdate()
        {
            _clock += Time.deltaTime;
        }

        private void OnDisable()
        {
            //Debug.Log(gameObject.name + " clock = " + _clock);
            _clock = 0f;
        }
    }
}