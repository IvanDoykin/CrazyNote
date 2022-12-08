using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _accuracy;
    [SerializeField] private TextMeshProUGUI _maxCombo;

    public void Initialize(int score, float accuracy, int maxCombo)
    {
        gameObject.SetActive(true);
        _score.text = score.ToString();
        _accuracy.text = "Accuracy: " + (accuracy * 100f).ToString("0.00");
        _maxCombo.text = "Max combo: " + maxCombo.ToString();
    }
}
