using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace InternalAssets.Scripts
{
    public abstract class SelectableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Action HasSelected;
        public Action HasClicked;

        [SerializeField] protected Button _button;
        public Button Button => _button;

        protected void Initialize()
        {
            _button.onClick.AddListener(() =>
            {
                HasClicked?.Invoke();
            });
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (_button.interactable)
            {
                HasSelected?.Invoke();
            }
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}