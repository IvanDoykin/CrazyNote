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
        private bool[] prevInput;

        private string _text = "";

        private string _lastDebug = "";
        private string _lastInput = "";

        public int kek = 0;
        public bool[] checkOnKeysDown = new bool[5];
        public bool[] testInput;

        private void Awake()
        {
            _input = GetComponent<GameInput>();
            prevInput = new bool[_input.GetInput().Notes.Length];
        }

        private void Update()
        {
            //reset only after 200ms delay
            InputData input = _input.GetInput();
            testInput = input.Notes;

            bool checkOnKeys = true;
            for (int i = 0; i < prevInput.Length; i++)
            {
                if (input.Notes[i] != prevInput[i])
                {
                    checkOnKeys = false;
                    break;
                }
            }

            if (checkOnKeys)
            {
                for (int i = 0; i < checkOnKeysDown.Length; i++)
                {
                    if (checkOnKeysDown[i]) return;
                }
            }
            else
            {
                for (int i = 0; i < prevInput.Length; i++)
                {
                    prevInput[i] = input.Notes[i];
                }
            }

            string debug = "{ ";
            foreach (var b in input.Notes)
            {
                debug += b + " ";
            }
            debug += "}";

            if (debug != "{ False False False False False }" && debug != _lastInput)
            {
                Debug.Log("input = " + debug);
                _lastInput = debug;
            }

            bool[] needInput = GetNeedInput();

            debug = "{ ";
            foreach (var b in needInput)
            {
                debug += b + " ";
            }
            debug += "}";

            if (debug != "{ False False False False False }" && debug != _lastDebug)
            {
                Debug.Log("debug = " + debug);
                _lastDebug = debug;
            }

            for (int i = 0; i < _detectors.Count; i++)
            {
                if (input.Notes[i] != needInput[i])
                {
                    return;
                }
            }

            for (int i = 0; i < _detectors.Count; i++)
            {
                if (needInput[i])
                {
                    checkOnKeysDown[i] = true;

                    _fireAnimators[i].Play();

                    while (_detectors[i].CatchFirstNote())
                    {
                        _score++;
                        _scoreText.text = "";
                        foreach (var ch in _score.ToString())
                        {
                            _scoreText.text += "<sprite=" + ch + ">";
                        }
                        _text = _scoreText.text;
                        _scoreText.text = _text + " kek:" + kek;
                    }
                }
            }

            _scoreText.text = "";
            foreach (var ch in _score.ToString())
            {
                _scoreText.text += "<sprite=" + ch + ">";
            }
            _text = _scoreText.text;
            _scoreText.text = _text + " kek:" + kek;

            ResetInput();
        }

        private void ResetInput()
        {
            var resetInput = _input.ResetInput();
            for (int i = 0; i < resetInput.Notes.Length; i++)
            {
                if (resetInput.Notes[i])
                {
                    checkOnKeysDown[i] = false;
                }
            }

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
