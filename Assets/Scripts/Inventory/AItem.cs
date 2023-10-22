using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AItem : MonoBehaviour, IItem
{
    public int Count { get; set; }
    public abstract void OnUse(PlayerController player);
}
