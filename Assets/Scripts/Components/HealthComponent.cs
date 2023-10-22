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
    public event Action<float> onHealthChanged;

    public float Health { get; private set; }

    private void Start()
    {
        Health = _health;
    }
    public void TakeDamage(float damage)
    {
        if (Health <= 0f)
            return;

        Health = Mathf.Max(Health - damage, 0);
        onHealthChanged?.Invoke(Health);

        if (Health <= 0f)
            onDead?.Invoke();
    }
}
