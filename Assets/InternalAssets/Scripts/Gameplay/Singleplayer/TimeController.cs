using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private Clock _clock;
        [SerializeField] private MusicPlayer _musicPlayer;

        public void Initialize(float time)
        {
            _clock.Activate(time);
        }
    }
}