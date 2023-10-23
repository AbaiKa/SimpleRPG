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

    public override bool Attack(Transform target, Vector2 direction)
    {
        if (CanAttack == false)
            return false;

        SetCooldown();

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _radiusAttack, _maskAttack.value);

        for(int i = 0; i < targets.Length; i++)
        {
            if (targets[i].CompareTag(TargetTag))
                targets[i].GetComponentInParent<HealthComponent>().TakeDamage(Damage);
        }

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusAttack);
    }
}
