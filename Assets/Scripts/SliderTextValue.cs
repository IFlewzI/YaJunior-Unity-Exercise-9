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
    }

    private void Update()
    {
        _text.text = _parentSlider.value.ToString();
    }
}
