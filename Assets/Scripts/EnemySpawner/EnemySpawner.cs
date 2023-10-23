using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private SpawnProps[] _spawnProps;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < _spawnProps.Length; i++)
        {
            for(int j = 0; j < _spawnProps[i].EnemyProps.Length; j++)
            {
                var prop = _spawnProps[i].EnemyProps[j];
                for (int k = 0; k < prop.Count; k++)
                {
                    Instantiate(prop.Enemy, _spawnProps[i].SpawnPoint.GetSpawnPoint(), Quaternion.identity);
                    yield return new WaitForSeconds(prop.SpawnCooldown);
                }
            }
        }
    }
}

[Serializable]
public struct SpawnProps
{
    [field: SerializeField]
    public SpawnPoint SpawnPoint {  get; private set; }

    [field: SerializeField]
    public EnemySpawnProps[] EnemyProps { get; private set; }
}
