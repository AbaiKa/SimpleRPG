using UnityEngine;

[RequireComponent(typeof(AttackComponent), typeof(HealthComponent), typeof(AnimationComponent))]
public abstract class AEnemy : MonoBehaviour
{
    protected AttackComponent attack;
    protected HealthComponent healthComponent;
    protected AnimationComponent animationComponent;

    protected virtual void Awake()
    {
        attack = GetComponent<AttackComponent>();
        healthComponent = GetComponent<HealthComponent>();
        animationComponent = GetComponent<AnimationComponent>();
    }

    protected abstract void Start();
    protected abstract void Update();
}
