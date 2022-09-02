using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class MainMenuUI : MonoBehaviour
    {
        public Action<Difficulty> DifficultyHasSelected;
        public Action StartGameHasClicked;
        public Action ExitButtonHasClicked;
        
        [SerializeField] private List<Button> _difficulties = new List<Button>();
        [SerializeField] private Button _startGame;
        [SerializeField] private Button _exitButton;
        
        private void Start()
        {
            for (int i = 0; i < _difficulties.Count; i++)
            {
                var index = i;
                _difficulties[index].GetComponent<TextMeshProUGUI>().color = Color.white;
                
                _difficulties[index].onClick.AddListener(() =>
                {
                    foreach (var difficulty in _difficulties)
                    {
                        difficulty.GetComponent<TextMeshProUGUI>().color = Color.white;
                    }
                    
                    _difficulties[index].GetComponent<TextMeshProUGUI>().color = Color.cyan;
                    DifficultyHasSelected?.Invoke((Difficulty)index);
                });
            }

            _startGame.onClick.AddListener(() => StartGameHasClicked?.Invoke());
            _exitButton.onClick.AddListener(() => ExitButtonHasClicked?.Invoke());
        }
    }
}