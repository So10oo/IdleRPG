using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "ScriptableObjects/Characteristics")]
public class CharacteristicsData : ScriptableObject
{
    [SerializeField] int _armor;
    [SerializeField] int _health;
    [SerializeField] int _attackPower;
    [SerializeField] int _preparationTime_ms;
    public int armor => _armor;
    public int health => _health;
    public int attackPower => _attackPower;
    public int preparationTime_ms => _preparationTime_ms;
}

