using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MainMenu
{
    public class DifficultyButton : CustomButton
    {
        [SerializeField] private Difficulty _difficulty;
        public Difficulty Difficulty => _difficulty;

        public static Action<DifficultyButton> HasClicked { get; set; }

        protected override void Start()
        {
            base.Start();
            _button.onClick.AddListener(() =>
            {
                HasClicked(this);
            });
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            HasClicked = null;
        }
    }
}