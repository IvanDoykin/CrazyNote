using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Singleplayer
{
    public class ComboCounter : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> _textFields;

        private void Start()
        {
            SetCombo(1488);
        }

        public void SetCombo(int combo)
        {
            string comboText = combo.ToString();
            for (int i = _textFields.Count - 1; i >= 0; i--)
            {
                if (i < comboText.Length) 
                {
                    _textFields[i].text = comboText[i].ToString(); 
                }
                else
                {
                    _textFields[i].text = "0";
                }
            }
        }
    }
}