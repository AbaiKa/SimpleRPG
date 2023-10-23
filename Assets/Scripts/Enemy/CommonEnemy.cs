using System.Collections;
using UnityEngine;

public class CommonEnemy : AEnemy
{
    [Header("Properties")]
    [SerializeField] protected string walkAnimationTrigger;
    [SerializeField] protected string deathAnimationTrigger;
    [SerializeField] protected string attackAnimationTrigger;

    private bool _rotated = false;

    #region Methods

    #region Unity
    private void Start()
    {
        attackComponent.onAttack += () => 
        { 
            animatorComponent.SetBool(attackAnimationTrigger, true);
        };

        healthComponent.onDead += () =>
        {
            animatorComponent.SetBool(deathAnimationTrigger, true);
            StartDestroyRoutine();
        };
    }

    private void Update()
    {
        if (!healthComponent.IsAlive)
            return;

        if (targetComponent.Target == null || attackComponent.onProcess)
        {
            ResetAnimation();
            return;
        }

        Movement(targetComponent.Target);
        Rotate(targetComponent.Target);

        Attack(targetComponent.Target);
    }

    private void OnDestroy()
    {
        attackComponent.onAttack -= () =>
        {
            animatorComponent.SetBool(attackAnimationTrigger, true);
        };

        healthComponent.onDead -= () =>
        {
            animatorComponent.SetBool(deathAnimationTrigger, true);
            StartDestroyRoutine();
        };
    }
    #endregion

    #region Protected
    protected override void Attack(Transform target)
    {
        attackComponent.TryAttack(target);
    }

    protected override void Movement(Transform target)
    {
        Vector2 a = transform.position;
        Vector2 b = target.position;

        transform.position = Vector2.MoveTowards(a, b, moveSpeed * Time.deltaTime);
        animatorComponent.SetBool(walkAnimationTrigger, true);
    }

    protected void Rotate(Transform target)
    {
        float distance = target.position.x - transform.position.x;

        if (_rotated == distance >= 0)
            return;

        Vector3 euler = new Vector3(0, distance >= 0 ? 0 : 180, 0);
        transform.rotation = Quaternion.Euler(euler);
        _rotated = distance >= 0;
    }

    protected void ResetAnimation()
    {
        animatorComponent.SetBool(walkAnimationTrigger, false);
        animatorComponent.SetBool(attackAnimationTrigger, false);
    }
    #endregion

    #endregion
}
