using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] HandBehaviour rightHandBehaviour;
    [SerializeField] HandBehaviour leftHandBehaviour;
    [SerializeField] AbilityContainerBehaviour ability1ContainerBehaviour;
    [SerializeField] AbilityContainerBehaviour ability2ContainerBehaviour;


    Weapon weapon1Data;
    Weapon weapon2Data;
    Weapon meleeWeaponData;

    //weaponAtack
    public void Atack()
    {
        PlayAtackAnimation();
    }
    public void SwitchWeapon()
    {
        rightHandBehaviour.SwitchWeapon();
        leftHandBehaviour.SwitchWeapon();
    }
    public void EquipWeapon(GameObject weapon)
    {
        rightHandBehaviour.EquipWeapon(weapon);
        animator.DisableAllLayers();


        SetWeaponAnimation(weapon.GetComponent<Weapon>().weaponType);
    }
    public void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        rightHandBehaviour.UnequipWeapon(weaponContainer);
    }

    //hability
    public void Hability1()
    {
        ability1ContainerBehaviour.UseAbility();
    }
    public void Hability2()
    {
        ability2ContainerBehaviour.UseAbility();
    }
    public void EquipHability1(GameObject ability)
    {
        ability1ContainerBehaviour.EquipAbility(ability);
    }
    public void EquipHability2(GameObject ability)
    {
        ability2ContainerBehaviour.EquipAbility(ability);
    }
    public void UnequipHability1()
    {
        ability1ContainerBehaviour.UnequipAbility();
    }
    public void UnequipHability2()
    {
        ability2ContainerBehaviour.UnequipAbility();
    }



    //animation
    void SetWeaponAnimation(WeaponType weaponType)
    {
        animator.SetLayerWeight((int)weaponType, 1);
    }
    public void PlayAtackAnimation()
    {
        animator.SetTrigger("Atack");
    }
}
