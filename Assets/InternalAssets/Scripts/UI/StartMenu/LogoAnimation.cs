using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public class LogoAnimation : MonoBehaviour
    {
        private const string scaleAnimation = "Scale";

        private const float fadeOutDuration = 2f;
        private const float endAlpha = 1f;

        [SerializeField] private Animator _animator;
        [SerializeField] private Image _logo;

        public void Play()
        {
            _animator.Play(scaleAnimation);
            _logo.CrossFadeAlphaFixed(endAlpha, fadeOutDuration, false);
        }
    }
}