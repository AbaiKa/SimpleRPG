using UnityEngine;

public class ItemBase
{
    [field: SerializeField]
    public Sprite Sprite {  get; private set; }

    [field: SerializeField]
    public ItemType ItemType { get; private set; }

    public int Count { get; set; }

    public ItemBase(ItemType type, Sprite sprite)
    {
        ItemType = type;
        Sprite = sprite;
        Count = 0;
    }
}
