using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class StartMenuSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;

        public void Play()
        {
            _audio.Play();
        }
    }
}