using System;
using UnityEngine;
using UnityEngine.UI;

public class MoblieInput : MonoBehaviour, IInput
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _fireButton;

    public event Action<Vector2> onMoveInput;
    public event Action<Vector2> onFireInput;

    public void Init()
    {
        _fireButton.onClick.AddListener(() => onFireInput?.Invoke(_joystick.Direction));
    }
    private void Update()
    {
        onMoveInput?.Invoke(new Vector2(_joystick.Horizontal, _joystick.Vertical));

        if (Input.GetKey(KeyCode.S))
        {
            onFireInput?.Invoke(_joystick.Direction);
        }
    }
}
