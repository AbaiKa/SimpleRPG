using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetTrackerComponent))]
public class PlayerAttack : MonoBehaviour
{
    private TargetTrackerComponent _targetComponent;

    [SerializeField]
    private AWeapon _currentWeapon;

    [SerializeField]
    private string _targetTag;

    private void Awake()
    {
        _targetComponent = GetComponent<TargetTrackerComponent>();
    }

    public void Attack(Vector2 direction)
    {
        _currentWeapon.Attack(_targetComponent.Target, direction);
    }
}
