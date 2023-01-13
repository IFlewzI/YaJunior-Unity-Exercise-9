using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ChangeHpButton : MonoBehaviour
{
    [SerializeField] private float _changeValue;
    [SerializeField] private UnityEvent<float> _buttonPressed;

    private void OnMouseUpAsButton()
    {
        _buttonPressed.Invoke(_changeValue);
    }
}
