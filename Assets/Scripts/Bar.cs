using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private float _changeSpeed;

    private Slider _slider;
    private DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> _sliderChangeTweener;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void SmoothlyChangeValue(float newValue)
    {
        if (newValue != _slider.value)
        {
            float changeValue = Math.Abs(_slider.value - newValue);
            float changeTime = changeValue / _changeSpeed;

            _sliderChangeTweener = _slider.DOValue(newValue, changeTime, true).SetEase(Ease.Linear);
        }
    }
}
