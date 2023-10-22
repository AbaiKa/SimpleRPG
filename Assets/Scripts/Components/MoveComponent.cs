using System;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 5f)]
    private float _speed;

    public void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
