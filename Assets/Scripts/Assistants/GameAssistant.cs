using System;
using UnityEngine;
using UnityEngine.UI;

public class GameAssistant : MonoBehaviour
{
    [Header("Base")]

    [SerializeField] private MoblieInput _input;
    [SerializeField] private InventoryPanel _inventory;

    [Header("Player prefab")]
    [SerializeField] private PlayerController _playerPrefab;
    private PlayerController _player;

    private void Awake()
    {
        _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        _player.Init(_input);

        _input.Init();
        _inventory.Init(_player);
    }
}
