using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : AWeapon
{
    [SerializeField]
    private ABullet _bulletPrefab;

    [SerializeField]
    private Transform _firePoint;

    public override bool Attack(Transform target, Vector2 direction)
    {
        if(CanAttack == false)
            return false;

        SetCooldown();

        if (target != null)
            direction = (target.position - _firePoint.position).normalized;

        if (direction.x == 0 && direction.y == 0)
            direction = _firePoint.right;

        ABullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.Release(direction.normalized, TargetTag, Damage);
        return true;
    }
}
