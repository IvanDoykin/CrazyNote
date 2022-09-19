using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetScore(int score)
        {
            _text.text = "";
            string scoreText = score.ToString();

            for (int i = 0; i < scoreText.Length; i++)
            {
                _text.text += "<sprite=" + scoreText[i] + ">";
            }
        }
    }
}