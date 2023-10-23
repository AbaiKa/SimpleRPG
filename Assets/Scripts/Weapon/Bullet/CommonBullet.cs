using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class CommonBullet : ABullet
{
    protected Rigidbody2D rigidbody2d;
    protected CircleCollider2D circleCollider2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        circleCollider2d = GetComponent<CircleCollider2D>();

        rigidbody2d.isKinematic = true;
        circleCollider2d.isTrigger = true;
    }

    public override void Release(Vector2 direction, string targetTag, float damage)
    {
        rigidbody2d.velocity = direction * Speed;
        this.targetTag = targetTag;
        this.damage = damage;

        Invoke(nameof(DestroyBullet), 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(targetTag))
        {
            var health = collision.GetComponentInParent<HealthComponent>();
            health.TakeDamage(damage);
            DestroyBullet();
        }
    }

    private void OnValidate()
    {
        if (rigidbody2d == null)
            rigidbody2d = GetComponent<Rigidbody2D>();
        if (circleCollider2d == null)
            circleCollider2d = GetComponent<CircleCollider2D>();

        rigidbody2d.isKinematic = true;
        circleCollider2d.isTrigger = true;
    }
}
