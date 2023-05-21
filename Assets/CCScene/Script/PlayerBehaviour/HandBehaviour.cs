using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    
    [SerializeField] Transform weapon1Container;
    [SerializeField] Transform weapon2Container;
    [SerializeField] Transform meleeWeaponContainer;
    [SerializeField] Weapon currentWeapon;
    [SerializeField] Weapon weapon1;
    [SerializeField] Weapon weapon2;
    [SerializeField] Weapon meleeWeapon;

    public void WeaponAtack()
    {
        currentWeapon.WeaponAtack();
    }
    public void WeaponAtacking()
    {

    }
    public void WeaponAtacked()
    {

    }
    public RuntimeAnimatorController EquipWeapon(GameObject weapon)
    {
        WeaponContainer weaponContainer;

        if (weapon1Container.childCount == 0)
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }
        else if (weapon2Container.childCount == 0)
        {
            weaponContainer = WeaponContainer.Weapon2Container;
        }
        else if (weapon1Container.gameObject.activeSelf == true)
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }
        else if (weapon2Container.gameObject.activeSelf == true)
        {
            weaponContainer = WeaponContainer.Weapon2Container;
        }
        else
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }


        UnequipWeapon(weaponContainer);
        EquipWeaponIn(weaponContainer);

        if(meleeWeaponContainer.gameObject.activeSelf == true)
        {
            UseWeapon(weaponContainer);
        }

        return currentWeapon.animatorController;

        void EquipWeaponIn(WeaponContainer weaponContainer)
        {
            if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
            {
                GameObject weaponInstance = Instantiate(weapon, meleeWeaponContainer);
                meleeWeapon = weaponInstance.GetComponent<Weapon>();
            }
            else if(weaponContainer == WeaponContainer.Weapon1Container)
            {
                GameObject weaponInstance = Instantiate(weapon, weapon1Container);
                weapon1 = weaponInstance.GetComponent<Weapon>();
            }
            else
            {
                GameObject weaponInstance = Instantiate(weapon, weapon2Container);
                weapon2 = weaponInstance.GetComponent<Weapon>();
            }
        }
    }
    public void UnequipWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
        {
            meleeWeaponContainer.DestroyAllChildren();

            meleeWeapon = null;
        }
        else if(weaponContainer == WeaponContainer.Weapon1Container)
        {
            weapon1Container.DestroyAllChildren();

            weapon1 = null;
        }
        else
        {
            weapon2Container.DestroyAllChildren();

            weapon2 = null;
        }
    }
    public RuntimeAnimatorController UseWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer && meleeWeaponContainer.childCount != 0)
        {
            currentWeapon = meleeWeapon;

            meleeWeaponContainer.gameObject.SetActive(true);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(false);
        }
        else if (weaponContainer == WeaponContainer.Weapon1Container && weapon1Container.childCount != 0)
        {
            currentWeapon = weapon1;
            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);
        }
        else if (weaponContainer == WeaponContainer.Weapon2Container && weapon2Container.childCount != 0)
        {
            currentWeapon = weapon2;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);
        }
        return currentWeapon.animatorController;
    }
    public RuntimeAnimatorController SwitchWeapon()
    {
        if(weapon1Container.gameObject.activeSelf == true && weapon2Container.childCount != 0)
        { 
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);
            meleeWeaponContainer.gameObject.SetActive(false);

            currentWeapon = weapon2;
        }
        else if (weapon2Container.gameObject.activeSelf == true && weapon1Container.childCount != 0)
        {
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);
            meleeWeaponContainer.gameObject.SetActive(false);

            currentWeapon = weapon1;
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == true && weapon1Container.childCount != 0)
        {
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);
            meleeWeaponContainer.gameObject.SetActive(false);

            currentWeapon = weapon1;
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == true && weapon2Container.childCount != 0)
        {
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);
            meleeWeaponContainer.gameObject.SetActive(false);

            currentWeapon = weapon2;
        }
        else 
        {
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(false);
            meleeWeaponContainer.gameObject.SetActive(true);

            currentWeapon = meleeWeapon; 
        }

        return currentWeapon.animatorController;
    }
}
