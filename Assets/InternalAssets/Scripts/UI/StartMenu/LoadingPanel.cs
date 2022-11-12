using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class LoadingPanel : MonoBehaviour
    {
        private const string loadingMenuText = "loading menu";

        [SerializeField] private TextMeshProUGUI _descriptionBackground;
        [SerializeField] private TextMeshProUGUI _description;

        public void LoadingMenu()
        {
            SetText(loadingMenuText);
        }

        private void SetText(string text)
        {
            _descriptionBackground.text = text;
            _description.text = text;
        }
    }
}
