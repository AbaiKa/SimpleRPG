using System;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField]
    private AWeapon _currentWeapon;

    [SerializeField]
    [Range(0, 10)]
    private float _attackDistance;


    public event Action onAttack;

    public bool onProcess => !_currentWeapon.CanAttack;

    public void SelectWeapon(AWeapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void TryAttack(Transform target)
    {
        if (target == null)
            return;

        if (_currentWeapon == null || _currentWeapon.CanAttack == false)
            return;

        if (SuitableDistance(target.position) == false)
            return;

        _currentWeapon.Attack(target);

        onAttack?.Invoke();
    }

    private bool SuitableDistance(Vector2 target)
    {
        return Vector2.Distance(transform.position, target) <= _attackDistance;
    }

    #region Helpers
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }
    #endregion
}
