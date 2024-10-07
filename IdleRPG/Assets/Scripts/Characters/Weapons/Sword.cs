using UnityEngine;


public class Sword : Weapon
{
    [SerializeField] Modifier AttackModifier;
    [SerializeField] Modifier ArmorModifier;

    public override void GiveImprovement(Characteristics characteristics)
    {
        var attackPower = characteristics.AttackPower;
        attackPower.AddModified(AttackModifier);
        var Armor = characteristics.Armor;
        Armor.AddModified(ArmorModifier);
    }

    public override void ResetImprovement(Characteristics characteristics)
    {
        var attackPower = characteristics.AttackPower;
        attackPower.RemoveModified(AttackModifier);
        var Armor = characteristics.Armor;
        Armor.RemoveModified(ArmorModifier);
    }
}

