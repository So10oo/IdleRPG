using System;
using UnityEngine;

[Serializable]
public class EnemySpawnData 
{
    [SerializeField] Enemy _enemyPrefab;

    [Range(0, 100)] public int ProbabilityOccurrence = 0;

    public Enemy enemyPrefab => _enemyPrefab;
}