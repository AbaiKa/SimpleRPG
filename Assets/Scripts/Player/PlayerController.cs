using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttack), typeof(PlayerMovement), typeof(InventoryComponent))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public HealthComponent Health {  get; private set; }
    [field: SerializeField]
    public InventoryComponent Inventory { get; private set; }

    private IInput _input;
    private PlayerAttack _attack;
    private PlayerMovement _movement;

    public void Init(IInput input)
    {
        _input = input;

        _attack = GetComponent<PlayerAttack>();
        _movement = GetComponent<PlayerMovement>();

        Health = GetComponent<HealthComponent>();
        Inventory = GetComponent<InventoryComponent>();

        _input.onMoveInput += _movement.Move;
        _input.onFireInput += _attack.Attack;

        Health.onDead += DestroyPlayer;
    }

    private void OnDestroy()
    {
        _input.onMoveInput -= _movement.Move;
        _input.onFireInput -= _attack.Attack;

        Health.onDead -= DestroyPlayer;
    }

    private void OnValidate()
    {
        Health = GetComponent<HealthComponent>();
        Inventory = GetComponent<InventoryComponent>();
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
