using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prop", menuName = "ScriptableObjects/Enemies/SpawnProps", order = 1)]
public class EnemySpawnProps : ScriptableObject
{
    [field: SerializeField]
    public AEnemy Enemy { get; private set; }

    [field: SerializeField]
    [field: Range(0, 30)]
    public int Count { get; private set; }

    [field: SerializeField]
    [field: Range(0, 30)]
    public float SpawnCooldown { get; private set; }
}
