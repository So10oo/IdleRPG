using UnityEngine;
using Zenject;

public class ButtonChangeWeapon : MonoBehaviour
{
    [SerializeField] Bow _bow;
    [SerializeField] Sword _sword;

    Player _player;

    [Inject]
    void Construct(Player character)
    {
        _player = character;
    }

    public void SetWeaponBow()
    {
        _player.ChangeWeapon(_bow);
    }
    public void SetWeaponSword()
    {
        _player.ChangeWeapon(_sword);
    }
}
