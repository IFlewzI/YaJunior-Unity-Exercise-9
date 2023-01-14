using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Color _colorAfterDamaged;
    [SerializeField] private Color _colorAfterHealed;
    [SerializeField] private float _colorEffectTime;

    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;
    private DG.Tweening.Core.TweenerCore<Color, Color, DG.Tweening.Plugins.Options.ColorOptions> _colorChangeTweener;
    [SerializeField] private float _hp;
    private float _maxHp;
    private float _minHp;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        _hp = 50;
        _maxHp = 100;
        _minHp = 0;
        _hpBar.value = _hp;
        _hpBar.maxValue = _maxHp;
        _hpBar.minValue = _minHp;
    }

    public void GetDamage(float damage)
    {
        if (Mathf.Clamp(_hp - damage, _minHp, _maxHp) < _hp)
            CreateEffectAfterDamage();

        _hp = Mathf.Clamp(_hp - damage, _minHp, _maxHp);
        _hpBar.gameObject.GetComponent<Bar>().SmoothlyChangeValue(_hp);
    }

    public void GetHeal(float healValue)
    {
        if (Mathf.Clamp(_hp + healValue, _minHp, _maxHp) > _hp)
            CreateEffectAfterHeal();

        _hp = Mathf.Clamp(_hp + healValue, _minHp, _maxHp);
        _hpBar.gameObject.GetComponent<Bar>().SmoothlyChangeValue(_hp);
    }

    private void CreateEffectAfterDamage()
    {
        _colorChangeTweener.Pause();
        _spriteRenderer.color = _defaultColor;
        _colorChangeTweener = _spriteRenderer.DOColor(_colorAfterDamaged, _colorEffectTime / 2).SetLoops(2, LoopType.Yoyo);
    }

    private void CreateEffectAfterHeal()
    {
        _colorChangeTweener.Pause();
        _spriteRenderer.color = _defaultColor;
        _colorChangeTweener = _spriteRenderer.DOColor(_colorAfterHealed, _colorEffectTime / 2).SetLoops(2, LoopType.Yoyo);
    }
}
