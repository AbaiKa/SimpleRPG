using System;
using UnityEngine;

public interface IInput
{
    /// <summary>
    /// Direction
    /// </summary>
    public event Action <Vector2> onMoveInput;

    /// <summary>
    /// Direction
    /// </summary>
    public event Action <Vector2> onFireInput;
}
