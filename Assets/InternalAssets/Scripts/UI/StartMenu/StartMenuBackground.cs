using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class StartMenuBackground : MonoBehaviour
    {
        private const float fullFadeInBlack = 0f;
        private const float fullFadeOutBlack = 0.85f;
        private const float fadeInTime = 1.8f;
        private const float fadeOutTime = 1f;

        [SerializeField] private Image _background;

        private void Awake()
        {
            SetDarkness(fullFadeInBlack, 0f);
        }

        public void FadeOutTo(float value)
        {
            SetDarkness(fullFadeInBlack + (fullFadeOutBlack - fullFadeInBlack) * value, Mathf.Abs(((value - (1f - fullFadeOutBlack + fullFadeInBlack)) - _background.color.r) * fadeOutTime));
        }

        public void FullFadeIn()
        {
            SetDarkness(fullFadeInBlack, fadeInTime);
        }

        public void InstantFadeIn()
        {
            SetDarkness(fullFadeOutBlack, 0f);
        }

        private void SetDarkness(float darkness, float time)
        {
            Color newColor = Color.white * darkness;
            newColor.a = 1f;
            _background.CrossFadeColorFixed(newColor, time, false, false);
        }
    }
}