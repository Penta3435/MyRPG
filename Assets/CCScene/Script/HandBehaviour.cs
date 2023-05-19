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
    public Weapon currentWeapon;
    Weapon weapon1;
    Weapon weapon2;
    Weapon meleeWeapon;

    public void Atack()
    {
        currentWeapon.WeaponAtackMethod();
    }
    public void EquipWeapon(GameObject weapon)
    {
        WeaponContainer weaponContainer;

        if (weapon1Container.GetChild(0).CompareTag("NoWeapon"))
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }
        else if(weapon2Container.GetChild(0).CompareTag("NoWeapon"))
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


        if(meleeWeapon.gameObject.activeSelf == true)
        {
            UseWeapon(weaponContainer);
        }
        
        
        
        void EquipWeaponIn(Transform weaponContainer)
        {

            var weaponInstance = Instantiate(weapon, weaponContainer);

            currentWeapon = weaponInstance.GetComponent<Weapon>();
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
    public void UseWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer && !meleeWeaponContainer.GetChild(0).CompareTag("NoWeapon"))
        {
            currentWeapon = meleeWeapon;

            meleeWeaponContainer.gameObject.SetActive(true);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(false);
        }
        else if (weaponContainer == WeaponContainer.Weapon1Container && !meleeWeaponContainer.GetChild(0).CompareTag("NoWeapon"))
        {
            currentWeapon = weapon1;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);
        }
        else if (weaponContainer == WeaponContainer.Weapon2Container && !meleeWeaponContainer.GetChild(0).CompareTag("NoWeapon"))
        {
            currentWeapon = weapon2;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);
        }
    }
    public void SwitchWeapon()
    {
        if(weapon1Container.gameObject.activeSelf == true)
        { 
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);

            currentWeapon = weapon2;
        }
        else
        {
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);

            currentWeapon = weapon1;
        }
    }
}
