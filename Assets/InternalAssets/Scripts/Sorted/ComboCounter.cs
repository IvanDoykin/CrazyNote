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
            SetCombo(1488);
        }

        public void SetCombo(int combo)
        {
            var comboText = combo.ToString();
            for (var i = _textFields.Count - 1; i >= 0; i--)
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