using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Button _btnSelf;

    [SerializeField] private Button _btnDrop;

    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private TextMeshProUGUI _txtItemsCount;
    [SerializeField] private Image _imgItemSprite;

    private ItemBase _item;
    private InventoryPanel _inventoryPanel;
    private InventoryComponent _inventoryComponent;

    private bool _isOpen;

    public void Init(ItemBase item, InventoryPanel panel, PlayerController player)
    {
        _item = item;
        _inventoryPanel = panel;
        _inventoryComponent = player.Inventory;

        _btnSelf.onClick.AddListener(OnSelfButtonClick);
        _btnDrop.onClick.AddListener(OnDropButtonClick);

        _isOpen = true;
        _txtItemsCount.text = item.Count.ToString();
        _imgItemSprite.sprite = item.Sprite;

        SetActiveButtonsPanel();
    }

    private void OnSelfButtonClick()
    {
        SetActiveButtonsPanel();
    }
    private void OnDropButtonClick()
    {
        // TODO: Создать копию предмета после дропа
        _inventoryPanel.RemoveItem(this);
        _inventoryComponent.RemoveItem(_item);
        SetActiveButtonsPanel();
        Destroy(gameObject);
    }

    private void SetActiveButtonsPanel()
    {
        _isOpen = !_isOpen;
        _buttonsPanel.SetActive(_isOpen);
    }
}
