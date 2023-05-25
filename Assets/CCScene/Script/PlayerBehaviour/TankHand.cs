using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHand : Hand
{
    public override Weapon EquipWeapon(GameObject weapon)
    {
        WeaponType weaponType = weapon.GetComponent<Weapon>().WeaponType;

        if (weaponType != WeaponType.TankWeapon && weaponType != WeaponType.TankMelee)
        {
            return null;
        }

        WeaponContainer weaponContainer;

        if (weaponType == WeaponType.TankMelee)
        {
            weaponContainer = WeaponContainer.MeleeWeaponContainer;
        }
        else
        {
            weaponContainer = WeaponContainer.Weapon1Container;
            UseWeapon(weaponContainer);
        }


        UnequipWeapon(weaponContainer);
        EquipWeaponIn(weaponContainer);

        if (meleeWeaponContainer.gameObject.activeSelf == true)
        {
            UseWeapon(weaponContainer);
        }

        return currentWeapon;

        void EquipWeaponIn(WeaponContainer weaponContainer)
        {
            if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
            {
                GameObject weaponInstance = Instantiate(weapon, meleeWeaponContainer);
                meleeWeapon = weaponInstance.GetComponent<Weapon>();
                characterUIBehaviour.MeleeWeaponImage = meleeWeapon.WeaponSprite;
            }
            else
            {
                GameObject weaponInstance = Instantiate(weapon, weapon1Container);
                weapon1 = weaponInstance.GetComponent<Weapon>();
                characterUIBehaviour.Weapon1Image = weapon1.WeaponSprite;
            }
        }
    }
    public override void UnequipWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
        {
            meleeWeaponContainer.DestroyAllChildren();

            meleeWeapon = null;
        }
        else
        {
            weapon1Container.DestroyAllChildren();

            weapon1 = null;
        }
    }
    public override Weapon UseWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer && meleeWeaponContainer.childCount != 0)
        {
            currentWeapon = meleeWeapon;

            meleeWeaponContainer.gameObject.SetActive(true);
            weapon1Container.gameObject.SetActive(false);

            characterUIBehaviour.EnableMeleeWeapon();
        }
        else if (weaponContainer == WeaponContainer.Weapon1Container && weapon1Container.childCount != 0)
        {
            currentWeapon = weapon1;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(true);

            characterUIBehaviour.EnableWeapon1();
        }
        UpdateUI();
        return currentWeapon;
    }
    public override Weapon SwitchWeapon()
    {
        if (weapon1Container.gameObject.activeSelf == true)
        {
            weapon1Container.gameObject.SetActive(false);
            meleeWeaponContainer.gameObject.SetActive(true);

            currentWeapon = meleeWeapon;
        }
        else
        {
            weapon1Container.gameObject.SetActive(true);
            meleeWeaponContainer.gameObject.SetActive(false);

            currentWeapon = weapon1;
        }
        UpdateUI();
        return currentWeapon;
    }
    protected override void UpdateUI()
    {
        if (weapon1Container.gameObject.activeSelf == true) characterUIBehaviour.EnableWeapon1();
        else if (meleeWeaponContainer.gameObject.activeSelf == true) characterUIBehaviour.EnableMeleeWeapon();
    }
}
