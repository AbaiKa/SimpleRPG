using System;
using UnityEngine;

[RequireComponent(typeof(DynamicJoystick))]
public class MoblieInput : MonoBehaviour, IInput
{
    public event Action<Vector2> onInputChanged;

    private DynamicJoystick _joystick;

    private void Awake()
    {
        _joystick = GetComponent<DynamicJoystick>();
    }

    private void Update()
    {
        onInputChanged?.Invoke(new Vector2(_joystick.Horizontal, _joystick.Vertical));
    }
}
