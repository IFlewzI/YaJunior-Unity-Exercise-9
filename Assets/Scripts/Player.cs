using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Color _colorAfterDamaged;
    [SerializeField] private Color _colorAfterHealed;
    [SerializeField] private float _colorEffectTime;
    [SerializeField] private UnityEvent<float> _hpChanged;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _defaultColor;
    private DG.Tweening.Core.TweenerCore<Color, Color, DG.Tweening.Plugins.Options.ColorOptions> _colorChangeTweener;
    private float _hp;
    private float _maxHp;
    private float _minHp;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        _hp = 50;
        _maxHp = 100;
        _minHp = 0;
        _hpChanged.Invoke(_hp);
    }

    public void GetHpChanges(float changeValue)
    {
        Color targetColor;
        _colorChangeTweener.Pause();

        if (_hp + changeValue > _maxHp)
        {
            _hp = _maxHp;
        }
        else if (_hp + changeValue < _minHp)
        {
            _hp = _minHp;
        }
        else
        {
            _hp += changeValue;

            if (_hp + changeValue > _hp)
                targetColor = _colorAfterHealed;
            else
                targetColor = _colorAfterDamaged;

            _spriteRenderer.color = _defaultColor;
            _colorChangeTweener = _spriteRenderer.DOColor(targetColor, _colorEffectTime / 2).SetLoops(2, LoopType.Yoyo);
        }

        _hpChanged.Invoke(_hp);
    }
}
