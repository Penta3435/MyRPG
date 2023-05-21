using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Transform hand;

    [SerializeField] protected Animator animator;
    [SerializeField] protected HandBehaviour rightHandBehaviour;
    [SerializeField] protected HandBehaviour leftHandBehaviour;
    [SerializeField] protected AbilityContainerBehaviour ability1ContainerBehaviour;
    [SerializeField] protected AbilityContainerBehaviour ability2ContainerBehaviour;


    //weapon
    public abstract void Atack();
    public abstract void WeaponAtack();
    public abstract void WeaponAtacking();
    public abstract void WeaponAtacked();
    public abstract void SwitchWeapon();
    public abstract void SwitchToMelee();
    public abstract void EquipWeapon(GameObject weapon);
    public abstract void UnEquipWeapons(WeaponContainer weaponContainer);

    //hability
    public abstract void Hability1();
    public abstract void Hability2();
    public abstract void EquipHability1(GameObject ability);
    public abstract void EquipHability2(GameObject ability);
    public abstract void UnequipHability1();
    public abstract void UnequipHability2();



    //animation
    public abstract void PlayAtackAnimation();
}
