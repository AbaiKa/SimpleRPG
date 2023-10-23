using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthComponent), typeof(AttackComponent), typeof(TargetTrackerComponent))]
public abstract class AEnemy : MonoBehaviour
{
    [Header("Base")]

    [SerializeField] 
    protected Animator animatorComponent;

    [SerializeField, Range(0, 5)] 
    protected float moveSpeed;

    [SerializeField]
    protected AItem onDeathItem;


    protected HealthComponent healthComponent;
    protected AttackComponent attackComponent;
    protected TargetTrackerComponent targetComponent;

    private bool _deadStart = false;

    protected virtual void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        attackComponent = GetComponent<AttackComponent>();
        targetComponent = GetComponent<TargetTrackerComponent>();

        _deadStart = false;
    }

    protected abstract void Attack(Transform target);
    protected abstract void Movement(Transform target);

    protected void StartDestroyRoutine()
    {
        if (_deadStart)
            return;

        _deadStart = true;

        Instantiate(onDeathItem, transform.position, Quaternion.identity);

        DestroyEnemy();
    }
    private void DestroyEnemy()
    {
        //TODO: return to pool
        Destroy(gameObject);
    }
}
