using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : MonoBehaviour 
{
    [SerializeField] protected Transform weapon1Container;
    [SerializeField] protected Transform meleeWeaponContainer;
    [SerializeField] protected Weapon currentWeapon;
    [SerializeField] protected Weapon weapon1;
    [SerializeField] protected Weapon meleeWeapon;

    public CharacterUIBehaviour characterUIBehaviour { protected get; set; }

    public virtual void WeaponAtack() {  }
    public virtual void WeaponAtacking() {  }
    public virtual void WeaponAtacked() {  }
    public abstract Weapon EquipWeapon(GameObject weapon, out bool used);
    public abstract void UnequipWeapon(WeaponContainer weaponContainer);
    public abstract Weapon UseWeapon(WeaponContainer weaponContainer, out bool used);
    public abstract Weapon SwitchWeapon( out bool switched);
    protected abstract void UpdateUI();

    protected void OnEnable()
    {
        UpdateUI();
    }
}
