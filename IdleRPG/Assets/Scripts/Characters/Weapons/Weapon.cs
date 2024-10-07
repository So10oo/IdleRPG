using UnityEngine;


public abstract class Weapon : MonoBehaviour, IImprovingCharacteristics
{
    [SerializeField] int _timeAttack_ms;

    [SerializeField] AttackType _type;
    public AttackType type => _type;
    public Stat timeAttackStat { private set; get; } = new Stat();

    private void Start()
    {
        timeAttackStat.SetBaseModified(new Modifier(_timeAttack_ms));
    }

    public abstract void GiveImprovement(Characteristics characteristics);
    public abstract void ResetImprovement(Characteristics characteristics);
}

