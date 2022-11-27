using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSideStretcher : MonoBehaviour
{
    private const float startStretchSize = 1.6f;
    private const float endStretchSize = 1f;

    private const float stretchTime = 0.3f;

    [SerializeField] private RectTransform _rect;

    [ContextMenu("Stretch")]
    public void Stretch()
    {
        StopAllCoroutines();
        StartCoroutine(SmoothStretch());
    }

    private IEnumerator SmoothStretch()
    {
        _rect.anchoredPosition = (startStretchSize - endStretchSize) * _rect.rect.width * Vector2.right / 2f;
        transform.localScale = new Vector3(startStretchSize, 1f, 1f);

        float timer = 0f;
        while (timer < stretchTime)
        {
            _rect.anchoredPosition = (1f + (startStretchSize - endStretchSize) * (1f - timer / stretchTime) - endStretchSize) * _rect.rect.width * Vector2.right / 2f;
            transform.localScale = new Vector3(1f + (startStretchSize - endStretchSize) * (1f - timer / stretchTime), 1f, 1f);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
