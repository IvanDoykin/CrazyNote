using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class SingleplayerDebug : MonoBehaviour
    {
        [SerializeField] private bool _active;
        [SerializeField] private GameObject _debug;

        private void Start()
        {
            _debug.SetActive(_active);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
            {
                _active = !_active;
                _debug.SetActive(_active);
            }
        }
    }
}