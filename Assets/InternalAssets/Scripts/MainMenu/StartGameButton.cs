using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MainMenu
{
    public class StartGameButton : MonoBehaviour
    {
        public static Action<StartGameButton> HasClicked { get; set; }

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() =>
            {
                HasClicked(this);
            });
        }

        private void OnDestroy()
        {
            HasClicked = null;
        }
    }
}