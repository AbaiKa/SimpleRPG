using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABullet : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float _speed;

    protected float damage;
    protected string targetTag;
    protected float Speed => _speed;
    public abstract void Release(Vector2 direction, string targetTag, float damage);
    protected void DestroyBullet()
    {
        // TODO: return to pool
        Destroy(gameObject);
    }
}
