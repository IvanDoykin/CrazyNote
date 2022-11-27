using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public Action AnyButtonHasSelected;
        public Action AnyButtonHasClicked;
        public Action ExitHasClicked;
        public Action OptionsHasClicked;

        [SerializeField] private Button _exit;
        [SerializeField] private Button _options;

        [SerializeField] private OneSideStretcher _background;
        private SelectableButton[] _buttons;

        private void Awake()
        {
            _buttons = GetComponentsInChildren<SelectableButton>();
            foreach (var button in _buttons)
            {
                button.HasSelected += () => AnyButtonHasSelected?.Invoke();
                button.HasClicked += () => AnyButtonHasClicked?.Invoke();
            }

            _exit.onClick.AddListener(() =>
            {
                ExitHasClicked?.Invoke();
            });

            _options.onClick.AddListener(() =>
            {
                OptionsHasClicked?.Invoke();
            });
        }

        public void Stretch()
        {
            _background.Stretch();
        }
    }
}