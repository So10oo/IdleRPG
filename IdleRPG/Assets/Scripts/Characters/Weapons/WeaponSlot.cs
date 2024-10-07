using System;
using UnityEngine;


public class WeaponSlot : MonoBehaviour
{
    [SerializeField] WeaponSlotView _weaponSlotView;
    [SerializeField] Weapon _startWeapon;
    public Action<Weapon> OnWeaponChange;
    Weapon _currentWeapon;

    public Weapon currentWeapon => _currentWeapon;
    public void SetWeapon(Characteristics characteristics, Weapon newWeapon)
    {
        _currentWeapon?.ResetImprovement(characteristics);
        _currentWeapon = newWeapon;
        _currentWeapon.GiveImprovement(characteristics);

        _weaponSlotView.WeaponView(newWeapon.type);
        OnWeaponChange?.Invoke(newWeapon);
    }

    private void Start()
    {
        SetWeapon(GetComponent<Character>().characteristics, _startWeapon);
    }

}
