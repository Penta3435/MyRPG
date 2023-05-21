using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : Character
{

    //weapon
    public override void Atack()
    {
        PlayAtackAnimation();
    }
    public override void WeaponAtack()
    {
        rightHandBehaviour.WeaponAtack();
    }
    public override void WeaponAtacking()
    {

    }
    public override void WeaponAtacked()
    {

    }
    public override void SwitchWeapon()
    {
        var animatorController = rightHandBehaviour.SwitchWeapon();
        animator.runtimeAnimatorController = animatorController;
    }
    public override void SwitchToMelee()
    {
        rightHandBehaviour.UseWeapon(WeaponContainer.MeleeWeaponContainer);
    }
    public override void EquipWeapon(GameObject weapon)
    {
        var animatorController = rightHandBehaviour.EquipWeapon(weapon);
        animator.runtimeAnimatorController = animatorController; 
    }
    public override void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        rightHandBehaviour.UnequipWeapon(weaponContainer);
    }

    //hability
    public override void Hability1()
    {
        ability1ContainerBehaviour.UseAbility();
    }
    public override void Hability2()
    {
        ability2ContainerBehaviour.UseAbility();
    }
    public override void EquipHability1(GameObject ability)
    {
        ability1ContainerBehaviour.EquipAbility(ability);
    }
    public override void EquipHability2(GameObject ability)
    {
        ability2ContainerBehaviour.EquipAbility(ability);
    }
    public override void UnequipHability1()
    {
        ability1ContainerBehaviour.UnequipAbility();
    }
    public override void UnequipHability2()
    {
        ability2ContainerBehaviour.UnequipAbility();
    }



    //animation
    public override void PlayAtackAnimation()
    {
        animator.SetTrigger("Atack");
    }
}
