using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class InputHolder : MonoBehaviour
    {
        private const float startHoldingTime = 0.15f;

        [SerializeField] private GuitarControl _control;

        public bool[] HoldingKeys
        {
            get
            {
                if (!Initialized)
                {
                    return new bool[0];
                }

                bool[] _temp = new bool[_holdingTimes.Length];
                for (int i = 0; i < _temp.Length; i++)
                {
                    _temp[i] = _holdingTimes[i] > 0f;
                }

                return _temp;
            }
        }

        private float[] _holdingTimes;
        public bool Initialized { get; private set; } = false;


        private void Start()
        {
            _control.InputHasChanged += HoldInput;
        }

        private void OnDestroy()
        {
            _control.InputHasChanged -= HoldInput;
        }

        private void Initialize(int inputLength)
        {
            Initialized = true;
            _holdingTimes = new float[inputLength];
        }

        private void HoldInput(bool[] input)
        {
            if (!Initialized)
            {
                Initialize(input.Length);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                {
                    _holdingTimes[i] = startHoldingTime;
                }
            }
        }

        public void Tick()
        {
            if (Initialized)
            {
                for (int i = 0; i < _holdingTimes.Length; i++)
                {
                    if (_holdingTimes[i] > 0)
                    {
                        _holdingTimes[i] -= Time.deltaTime;
                    }
                }
            }
        }
    }
}