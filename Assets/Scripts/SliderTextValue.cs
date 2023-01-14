using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SliderTextValue : MonoBehaviour
{
    private Slider _parentSlider;
    private Text _text;

    private void Start()
    {
        _parentSlider = GetComponentInParent<Slider>();
        _text = GetComponent<Text>();
        TextUpdate();
    }

    public void TextUpdate()
    {
        _text.text = _parentSlider.value.ToString();
    }
}
