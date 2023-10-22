using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _idleAnimationName = "idle";

    [SerializeField]
    private string _walkAnimationName = "walk";

    [SerializeField]
    private string _attackAnimationName = "attack";

    [SerializeField]
    private string _deadAnimationName = "dead";

    public void PlayIdle()
    {
        _animator.Play(_idleAnimationName);
    }
    public void PlayWalk()
    {
        _animator.Play(_walkAnimationName);
    }
    public void PlayAttack()
    {
        _animator.Play(_attackAnimationName);
    }
    public void PlayDead()
    {
        _animator.Play(_deadAnimationName);
    }
}
