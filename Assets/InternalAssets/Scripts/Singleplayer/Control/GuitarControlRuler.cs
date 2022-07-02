using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Singleplayer
{
    public class GuitarControlRuler : MonoBehaviour
    {
        [SerializeField] private List<NoteDetector> _detectors = new List<NoteDetector>();
        [SerializeField] private List<FireAnimator> _fireAnimators = new List<FireAnimator>();
        private GameInput _input;

        private int _score = 0;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public int kek = 0;

        private bool[] _lastInput;
        private float _timer = 0f;

        private void Awake()
        {
            _input = GetComponent<GameInput>();
        }

        private void Update()
        {
            bool[] currentInput = _input.GetInput().Notes;
            bool[] needInput = GetNeedInput();
            bool islastInputUpdated = UpdateLastInput(currentInput);

            UpdateTimer(islastInputUpdated);
            UpdateLastInputByTimer();

            if (CheckLastInputOnEmpty(_lastInput))
            {
                return;
            }
            for (int i = 0; i < _lastInput.Length; i++)
            {
                if (_lastInput[i] != needInput[i])
                {
                    //miss key
                    return;
                }
            }


        }

        private void UpdateLastInputByTimer()
        {
            if (_timer > 0.2f)
            {
                _timer = 0f;
                for (int i = 0; i < _lastInput.Length; i++)
                {
                    _lastInput[i] = false;
                }
            }
        }

        private bool CheckLastInputOnEmpty(bool[] lastInput)
        {
            foreach (var input in lastInput)
            {
                if (input)
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateTimer(bool islastInputUpdated)
        {
            if (islastInputUpdated)
            {
                _timer = 0f;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        private bool UpdateLastInput(bool[] currentInput)
        {
            bool isEverNoteTapped = false;
            foreach (var input in currentInput)
            {
                if (input)
                {
                    isEverNoteTapped = true;
                    _lastInput = currentInput;
                    break;
                }
            }

            return isEverNoteTapped;
        }

        private bool[] GetNeedInput()
        {
            bool[] needInput = new bool[_detectors.Count];
            int minPosition = 1024 * 1024 * 1024;

            foreach (var detector in _detectors)
            {
                var note = detector.GetFirstNote();
                if (note == null) continue;

                if (note.Position < minPosition)
                {
                    minPosition = note.Position;
                }
            }

            for (int i = 0; i < _detectors.Count; i++)
            {
                var note = _detectors[i].GetFirstNote();
                if (note == null) continue;

                if (note.Position == minPosition)
                {
                    needInput[i] = true;
                }
            }

            return needInput;
        }
    }
}
