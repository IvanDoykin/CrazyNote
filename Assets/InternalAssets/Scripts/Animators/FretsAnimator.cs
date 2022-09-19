using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class FretsAnimator : MonoBehaviour
    {
        private const int notesCount = 5;
        private const int pressedFretModifier = 0;
        private const int releasedFretModifier = 1;

        [SerializeField] private Texture2D _fretsTexture;

        [SerializeField] private List<SpriteRenderer> _frets;
        [SerializeField] private InputModifier _input;
        private Sprite[] _fretsSprites;

        private void Start()
        {
            _fretsSprites = Resources.LoadAll<Sprite>(_fretsTexture.name);
        }

        private void Update()
        {
            var activeInput = _input.LastFilteredInput;
            for (var i = 0; i < _frets.Count; i++)
            {
                SetFret(i, activeInput[i]);
            }
        }

        private void SetFret(int index, bool pressed)
        {
            if (pressed)
            {
                _frets[index].sprite = _fretsSprites[index + notesCount * pressedFretModifier];
            }
            else
            {
                _frets[index].sprite = _fretsSprites[index + notesCount * releasedFretModifier];
            }
        }
    }
}