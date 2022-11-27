using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace InternalAssets.Scripts
{
    public class SelectableSpriteButton : SelectableButton
    {
        [SerializeField] private Image _image;

        [SerializeField] private Sprite _activeSprite;
        [SerializeField] private Sprite _inactiveSprite;

        private void Start()
        {
            Initialize();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (_button.interactable)
            {
                _image.sprite = _activeSprite;
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if (_button.interactable)
            {
                _image.sprite = _inactiveSprite;
            }
        }
    }
}