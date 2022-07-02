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

        public bool[] _lastInput;
        private float _timer = 0f;

        private void Awake()
        {
            _input = GetComponent<GameInput>();
            _lastInput = new bool[_input.GetInput().Notes.Length];
        }

        private void Update()
        {
            bool[] currentInput = _input.GetInput().Notes;
            bool[] needInput = GetNeedInput();
            bool islastInputUpdated = UpdateLastInput(currentInput);

            Debug.Log(islastInputUpdated);

            UpdateTimer(islastInputUpdated);
            UpdateLastInputByTimer();

            if (CheckLastInputOnEmpty())
            {
                return;
            }

            if (islastInputUpdated)
            {
                ResetTimer();
            }

            if (CheckOnMiss(needInput))
            {
                //miss event
                return;
            }

            TriggerNotes(needInput);
            ResetLastInput();

            _scoreText.text = "" + _score + " " + kek;
        }

        private void TriggerNotes(bool[] needInput)
        {
            for (int i = 0; i < needInput.Length; i++)
            {
                if (needInput[i])
                {
                    _fireAnimators[i].Play();
                    while (_detectors[i].CatchFirstNote())
                    {
                        _score++;
                    }
                }
            }
        }

        private bool CheckOnMiss(bool[] needInput)
        {
            for (int i = 0; i < _lastInput.Length; i++)
            {
                if (_lastInput[i] != needInput[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateLastInputByTimer()
        {
            if (_timer > 0.1f)
            {
                Debug.Log("reset");
                ResetTimer();
                ResetLastInput();
            }
        }

        private bool CheckLastInputOnEmpty()
        {
            foreach (var input in _lastInput)
            {
                if (input)
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateTimer(bool islastInputUpdated)
        {
            if (islastInputUpdated)
            {
                ResetTimer();
            }
            else
            {
                Debug.Log("Inc timer");
                _timer += Time.deltaTime;
            }
        }

        private void ResetLastInput()
        {
            Debug.Log("reset last input");
            for (int i = 0; i < _lastInput.Length; i++)
            {
                _lastInput[i] = false;
            }
        }

        private void ResetTimer()
        {
            _timer = 0f;
        }

        private bool UpdateLastInput(bool[] currentInput)
        {
            bool isEverNoteTapped = false;
            foreach (var input in currentInput)
            {
                if (input)
                {
                    isEverNoteTapped = true;
                    for (int i = 0; i < _lastInput.Length; i++)
                    {
                        _lastInput[i] = currentInput[i];
                    }
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
