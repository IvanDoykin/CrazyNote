using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class ComboCounter : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> _textFields;

        private void Start()
        {
            SetCombo(135);
        }

        public void SetCombo(int combo)
        {
            var comboText = combo.ToString();
            var difference = _textFields.Count - comboText.Length;
            for (int i = comboText.Length - 1; i >= 0; i--)
            {
                _textFields[i + difference].text = comboText[i].ToString();
            }

            for (int i = 0; i < difference; i++)
            {
                _textFields[i].text = "0";
            }
        }
    }
}