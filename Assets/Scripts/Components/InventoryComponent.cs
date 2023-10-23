using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public List<ItemBase> Items { get; private set; } = new List<ItemBase>();

    public void AddItem(ItemBase item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (item.ItemType == Items[i].ItemType)
            {
                Items[i].Count++;
                return;
            }
        }

        item.Count = 1;
        Items.Add(item);
    }

    public void RemoveItem(ItemBase item)
    {
        if (!Items.Contains(item))
            return;

        Items.Remove(item);
    }
}

[Serializable]
public enum ItemType
{
    Bulletproof,
    Helmet
}