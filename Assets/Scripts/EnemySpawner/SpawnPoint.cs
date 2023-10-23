using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float _spawnRadius;

    public Vector2 GetSpawnPoint()
    {
        return Random.insideUnitCircle * _spawnRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}
