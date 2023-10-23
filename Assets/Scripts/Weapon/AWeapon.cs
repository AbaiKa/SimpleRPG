using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    #region Properties
    [SerializeField]
    [Tooltip("Weapon damage")]
    [Range(0, 100)]
    private float _damage;

    [SerializeField]
    [Tooltip("Weapon cooldown")]
    [Range(0f, 10f)]
    private float _cooldown;

    [SerializeField]
    [Tooltip("Target tag")]
    private string _targetTag;
    #endregion

    public float Damage => _damage;
    public string TargetTag => _targetTag;
    public bool CanAttack => currentCooldown <= 0;


    protected float currentCooldown;

    public abstract bool Attack(Transform target, Vector2 direction);

    protected virtual void Update()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
    protected void SetCooldown()
    {
        currentCooldown = _cooldown;
    }

    #region Helper
    private void OnValidate()
    {
        _damage = Mathf.Round(_damage * 100) * 0.01f;
        _cooldown = Mathf.Round(_cooldown * 100) * 0.01f;
    }
    #endregion
}
