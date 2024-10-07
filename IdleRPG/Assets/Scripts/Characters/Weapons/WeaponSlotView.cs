using System;
using UnityEngine;

public class WeaponSlotView : MonoBehaviour 
{
    [SerializeField] GameObject[] swordObjects;
    [SerializeField] GameObject[] bowObjects;

    public AttackType type { get; private set; }

    public void WeaponView(AttackType attackType)
    {
        type = attackType;
        switch (attackType)
        {
            case AttackType.Melee:
                View(true);
                break;
            case AttackType.Distant:
                View(false);
                break;
            default:
                break;
        }
    }

    void View(bool isSword)
    {
        foreach (var obj in swordObjects)
            obj.SetActive(isSword);
        foreach (var obj in bowObjects)
            obj.SetActive(!isSword);
    }
}

[Serializable]
public enum AttackType
{
    Melee,
    Distant
}