using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class Options : MonoBehaviour
    {
        public Action AnyButtonHasSelected;
        public Action AnyButtonHasClicked;
        public Action BackHasClicked;

        [SerializeField] private Button _back;
        private SelectableButton[] _buttons;

        private void Awake()
        {
            _buttons = GetComponentsInChildren<SelectableButton>(true);
            foreach (var button in _buttons)
            {
                button.HasSelected += () => AnyButtonHasSelected?.Invoke();

                if (button.Button != _back)
                {
                    button.HasClicked += () => AnyButtonHasClicked?.Invoke();
                }
            }

            _back.onClick.AddListener(() =>
            {
                BackHasClicked?.Invoke();
            });
        }

    }
}