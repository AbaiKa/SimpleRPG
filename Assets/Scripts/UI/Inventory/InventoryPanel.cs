using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private PlayerController _player;

    [SerializeField] private InventoryItem _itemPrefab;

    [SerializeField] private Button _openBtn;
    [SerializeField] private Button _closeBtn;

    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _panel;

    private List<InventoryItem> _items = new List<InventoryItem>();

    public void Init(PlayerController player)
    {
        _player = player;

        _openBtn.onClick.AddListener(Open);
        _closeBtn.onClick.AddListener(Close);   

        Close();
    }
    public void RemoveItem(InventoryItem item)
    {
        if (!_items.Contains(item))
            return;

        _items.Remove(item);
    }

    private void Open()
    {
        _panel.SetActive(true);

        for (int i = 0; i < _player.Inventory.Items.Count; i++)
        {
            var item = Instantiate(_itemPrefab, _container);
            item.Init(_player.Inventory.Items[i], this, _player);
            _items.Add(item);
        }
    }

    private void Close()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            Destroy(_items[i].gameObject);
        }

        _items.Clear();

        _panel.SetActive(false);
    }
}
