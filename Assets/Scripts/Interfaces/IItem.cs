using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public int Count { get; set; }
    public void OnUse(PlayerController player);
}
