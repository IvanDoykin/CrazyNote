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
        public Action BackButtonHasClicked;
        public Action ExitHasClicked;

        [SerializeField] private Button _exit;
        [SerializeField] private Button _options;

        [SerializeField] private OneSideStretcher _background;
        private SelectableButton[] _buttons;

        private void Awake()
        {
            _buttons = FindObjectsOfType<SelectableButton>(true);
            foreach (var button in _buttons)
            {
                button.HasSelected += () => AnyButtonHasSelected?.Invoke();

                if (button.GetComponent<BackButton>() != null)
                {
                    button.HasClicked += () => BackButtonHasClicked?.Invoke();
                }
                else
                {
                    button.HasClicked += () => AnyButtonHasClicked?.Invoke();
                }
            }

            _exit.onClick.AddListener(() =>
            {
                ExitHasClicked?.Invoke();
            });
        }

        public void Open()
        {
            gameObject.SetActive(true);
            Stretch();
        }

        private void Stretch()
        {
            _background.Stretch();
        }
    }
}