using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public abstract class CustomButton : MonoBehaviour
    {
        public static Action OnClicked { get; private set; }

        [SerializeField] private Color _activeColor = new Color(0.6148985f, 0.8867924f, 0.8790441f);
        [SerializeField] private Color _inactiveColor = new Color(0.7169812f, 0.7169812f, 0.7169812f);

        protected Button _button;
        private TextMeshProUGUI _text;

        protected virtual void Start()
        {
            _button = GetComponent<Button>();
            _text = GetComponent<TextMeshProUGUI>();

            OnClicked += () => SetActive(false);

            _button.onClick.AddListener(() =>
            {
                OnClicked();
                SetActive(true);
            });
        }

        protected virtual void OnDestroy()
        {
            OnClicked = null;
        }

        private void SetActive(bool state)
        {
            if (state)
            {
                _text.color = _activeColor;
            }
            else
            {
                _text.color = _inactiveColor;
            }
        }
    }
}