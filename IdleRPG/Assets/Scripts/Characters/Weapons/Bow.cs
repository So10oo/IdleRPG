using UnityEngine;


public class Bow : Weapon
{
    [SerializeField] Modifier AttackModifier;
    public override void GiveImprovement(Characteristics characteristics)
    {
        var attackPower = characteristics.AttackPower;
        attackPower.AddModified(AttackModifier);
    }

    public override void ResetImprovement(Characteristics characteristics)
    {
        var attackPower = characteristics.AttackPower;
        attackPower.RemoveModified(AttackModifier);
    }
}

