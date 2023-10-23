using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthComponent _healthComponent;

    [SerializeField]
    private Image _fillImage;

    private void Start()
    {
        _healthComponent.onHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float current, float max)
    {
        float onePercent = max / 100;
        float currentPercent = current / onePercent;
        float reslut = currentPercent / 100;

        _fillImage.fillAmount = reslut;
    }
}
