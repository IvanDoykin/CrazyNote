using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Singleplayer
{
    public class GuitarControlRuler : MonoBehaviour
    {
        [SerializeField] private List<NoteDetector> _detectors = new List<NoteDetector>();
        private GameInput _input;

        private int _score = 0;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _input = GetComponent<GameInput>();
        }

        private void Update()
        {
            InputData input = _input.GetInput();
            bool[] needInput = GetNeedInput();

            string debug = "{ ";
            foreach (var b in needInput)
            {
                debug += b + " ";
            }
            debug += "}";
            Debug.Log("debug = " + debug);

            for (int i = 0; i < _detectors.Count; i++)
            {
                if (input.Notes[i] != needInput[i])
                {
                    //gg wp
                    return;
                }
            }

            for (int i = 0; i < _detectors.Count; i++)
            {
                if (needInput[i])
                {
                    _detectors[i].CatchFirstNote();
                    _score++;
                }
            }
            _scoreText.text = _score.ToString();
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
