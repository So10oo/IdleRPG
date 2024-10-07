using ModestTree;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationData", menuName = "ScriptableObjects/LocationData")]
public class LocationData : ScriptableObject
{
    [SerializeField] Sprite _background;
    public Sprite background => _background;

    [SerializeField] List<EnemySpawnData> _enemies;
    public List<EnemySpawnData> enemies => _enemies;

    private void OnValidate()
    {
        if (enemies.IsEmpty())
            return;

        var sum = enemies.Sum(x => x.ProbabilityOccurrence);
        if (sum > 100)
        {
            var probability = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (probability + enemies[i].ProbabilityOccurrence >= 100)
                {
                    enemies[i].ProbabilityOccurrence = 100 - probability;
                }
                probability += enemies[i].ProbabilityOccurrence;
            }
        }
        else if (sum < 100)
        {
            enemies[enemies.Count-1].ProbabilityOccurrence += 100 - sum;
        }
    }

}


