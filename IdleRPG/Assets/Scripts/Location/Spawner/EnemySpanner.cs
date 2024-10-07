using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpanner : MonoBehaviour
{
    [SerializeField] Transform _spawnPosition;

    List<EnemySpawnData> spawnData;

    public Action<Enemy> OnEnemySpawn;
    FactoryWithDiContainer _factory;

    [Inject]
    void Construct(FactoryWithDiContainer factory, GameCurrentData gameCurrentData)
    {
        spawnData = gameCurrentData.locationData.enemies;
        _factory = factory;
    }

    public void SpawnEnemy()
    {
        Enemy enemyPrefab = GetRandomEnemy();
        var enemy = _factory.Create(enemyPrefab, position: _spawnPosition.position, parent: _spawnPosition);//Instantiate(enemyPrefab, _spawnPosition);
        enemy.OnStart += OnSpawnInvoke;
    }

    void OnSpawnInvoke(Enemy enemy)
    {
        OnEnemySpawn?.Invoke(enemy);
        enemy.OnStart -= OnSpawnInvoke;
    }

    Enemy GetRandomEnemy()
    {
        var enemiesData = spawnData;
        int leftMark = 0;
        int rightMark = 0;
        int random = UnityEngine.Random.Range(0, 101);
        for (int i = 0; i < enemiesData.Count; i++)
        {
            rightMark += enemiesData[i].ProbabilityOccurrence;
            if (leftMark < random && rightMark > random)
                return enemiesData[i].enemyPrefab;
            else
                leftMark += enemiesData[i].ProbabilityOccurrence;
        }
        Debug.Log("error", this);
        return enemiesData[^1].enemyPrefab;
    }
}

     

