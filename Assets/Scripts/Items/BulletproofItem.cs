using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletproofItem : AItem
{
    [SerializeField]
    [Range(0, 30)]
    private int _plusHp;
    public override void OnUse(PlayerController player)
    {
        // Plus +hp etc
    }
}
