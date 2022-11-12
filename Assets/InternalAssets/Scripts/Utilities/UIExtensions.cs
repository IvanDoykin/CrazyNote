using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Scripts
{
    public static class UIExtensions
    {
        public static void CrossFadeAlphaFixed(this Image img, float alpha, float duration, bool ignoreTimeScale)
        {
            Color fixedColor = img.color;
            fixedColor.a = 1f;
            img.color = fixedColor;

            img.CrossFadeAlpha(0f, 0f, true);

            img.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
        }

        public static void CrossFadeColorFixed(this Image img, Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
        {
            GameObject.FindObjectOfType<MonoBehaviour>().StartCoroutine(Test(img, targetColor, duration, ignoreTimeScale, useAlpha));
        }

        private static IEnumerator Test(Image img, Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
        {
            Color startColor = img.color;

            float timer = 0f;
            while (timer < duration)
            {
                img.color = Color.Lerp(startColor, targetColor, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }

            img.color = targetColor;
        }
    }
}