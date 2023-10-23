using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamagable
{
    #region Properties
    [SerializeField]
    [Range(0f, 100f)]
    private float _health;

    #endregion

    public event Action onDead;
    /// <summary>
    /// 1 Current value |||
    /// 2 Max value
    /// </summary>
    public event Action<float, float> onHealthChanged;

    public float Health { get; private set; }
    public bool IsAlive => Health > 0f;

    private void Start()
    {
        Health = _health;
    }
    public void TakeDamage(float damage)
    {
        if (!IsAlive)
        {
            return;
        }

        Health -= damage;

        onHealthChanged?.Invoke(Health, _health);

        if (Health <= 0f)
            onDead?.Invoke();
    }

    public void AddHp(float value)
    {
        if (Health == _health)
            return;

        Health = Mathf.Min(Health + value, _health);
    }
}
