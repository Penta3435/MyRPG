using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHand : Hand
{
    public override Weapon EquipWeapon(GameObject weapon, out bool used)
    {
        WeaponType weaponType = weapon.GetComponent<Weapon>().WeaponType;
        used = false;

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
        }


        UnequipWeapon(weaponContainer);
        EquipWeaponIn(weaponContainer);

        if (meleeWeaponContainer.gameObject.activeSelf == true)
        {
            UseWeapon(weaponContainer, out used);
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
    public override Weapon UseWeapon(WeaponContainer weaponContainer, out bool used)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer && meleeWeaponContainer.childCount != 0 && currentWeapon != meleeWeapon)
        {
            currentWeapon = meleeWeapon;
            used = true;

            meleeWeaponContainer.gameObject.SetActive(true);
            weapon1Container.gameObject.SetActive(false);

            characterUIBehaviour.EnableMeleeWeapon();
        }
        else if (weaponContainer == WeaponContainer.Weapon1Container && weapon1Container.childCount != 0 && currentWeapon != weapon1)
        {
            currentWeapon = weapon1;
            used = true;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(true);

            characterUIBehaviour.EnableWeapon1();
        }
        else used = false;

        return currentWeapon;
    }
    public override Weapon SwitchWeapon(out bool switched)
    {
        if (meleeWeaponContainer.gameObject.activeSelf == true && weapon1Container.transform.childCount == 1)
        {
            UseWeapon(WeaponContainer.Weapon1Container, out switched);
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == false)
        {
            UseWeapon(WeaponContainer.MeleeWeaponContainer, out switched);
        }
        else switched = false;

        return currentWeapon;
    }
    protected override void UpdateUI()
    {
        if (weapon1Container.gameObject.activeSelf == true) characterUIBehaviour.EnableWeapon1();
        else if (meleeWeaponContainer.gameObject.activeSelf == true) characterUIBehaviour.EnableMeleeWeapon();
    }
}
