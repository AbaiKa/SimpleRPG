using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MeleeWeapon : AWeapon
{
    [Header("Properties")]

    [SerializeField]
    private LayerMask _maskAttack;

    [SerializeField]
    [Range(0f, 2f)]
    private float _radiusAttack;

    [SerializeField]
    [Range(0f, 1f)]
    private float _durationAttack;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.isKinematic = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void Attack(Transform target)
    {
        SetCooldown();

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _radiusAttack, _maskAttack.value);

        for(int i = 0; i < targets.Length; i++)
        {
            targets[i].GetComponent<HealthComponent>().TakeDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusAttack);
    }
}
