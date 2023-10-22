using UnityEngine;

[RequireComponent(typeof(MoveComponent), typeof(RotationComponent), typeof(TargetTrackerComponent))]
public class CommonEnemy : AEnemy
{
    protected MoveComponent moveComponent;
    protected RotationComponent rotationComponent;
    protected TargetTrackerComponent targetTracker;

    protected override void Awake()
    {
        base.Awake();

        moveComponent = GetComponent<MoveComponent>();
        rotationComponent = GetComponent<RotationComponent>();
        targetTracker = GetComponent<TargetTrackerComponent>();
    }

    protected override void Start()
    {
        attack.onAttack += animationComponent.PlayAttack;
        healthComponent.onDead += animationComponent.PlayDead;
    }

    protected override void Update()
    {
        if (targetTracker.Target == null)
        {
            animationComponent.PlayIdle();
            return;
        }

        if (attack.onProcess)
        {
            return;
        }

        attack.TryAttack(targetTracker.Target);
        moveComponent.Move(targetTracker.Target.position);
        rotationComponent.Rotate(targetTracker.Target);

        animationComponent.PlayWalk();
    }

    private void OnDestroy()
    {
        attack.onAttack -= animationComponent.PlayAttack;
        healthComponent.onDead -= animationComponent.PlayDead;
    }
}
