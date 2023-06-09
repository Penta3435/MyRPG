using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform CharacterUIParent { protected get; set; }
    public Transform Hand { get => rightHandBehaviour.transform; }


    [SerializeField] protected Animator animator;
    [SerializeField] protected Hand rightHandBehaviour;
    [SerializeField] protected AbilityContainer ability1ContainerBehaviour;
    [SerializeField] protected AbilityContainer ability2ContainerBehaviour;
    [SerializeField] protected GameObject characterUIPrefab;
    private CharacterUIBehaviour characterUIBehaviour;
    public CharacterUIBehaviour CharacterUIBehaviour
    {
        protected get
        {
            return characterUIBehaviour;
        }
        set
        {
            characterUIBehaviour = value;
            rightHandBehaviour.characterUIBehaviour = value;
        }
    }

    //weapon
    public virtual void Atack()
    {
        PlayAtackAnimation();
    }
    public virtual void WeaponAtack()
    {
        rightHandBehaviour.WeaponAtack();
    }
    public virtual void WeaponAtacking()
    {
        rightHandBehaviour.WeaponAtacking();
    }
    public virtual void WeaponAtacked()
    {
        rightHandBehaviour.WeaponAtacked();
    }
    public virtual void SwitchWeapon()
    {
        Weapon equipedWeapon = rightHandBehaviour.SwitchWeapon(out bool switched);
        if (switched)
        {
            animator.SetTrigger("Idle");
            animator.runtimeAnimatorController = equipedWeapon.AnimatorController;
        }
    }
    public virtual void SwitchToMelee()
    {
        Weapon equipedWeapon = rightHandBehaviour.UseWeapon(WeaponContainer.MeleeWeaponContainer, out bool used);
        if (used) 
        { 
            animator.SetTrigger("Idle");
            animator.runtimeAnimatorController = equipedWeapon.AnimatorController;
        }
    }
    public virtual void EquipWeapon(GameObject weapon)
    {
        var weaponComponent = rightHandBehaviour.EquipWeapon(weapon, out bool equiped);
        if (equiped) animator.runtimeAnimatorController = weaponComponent.AnimatorController;
    }
    public virtual void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        rightHandBehaviour.UnequipWeapon(weaponContainer);
    }

    //hability
    public virtual void Ability1(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController)
    {
        ability1ContainerBehaviour.UseAbility(movementDirection, mousePosition, playerController);
    }
    public virtual void Ability2(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController)
    {
        ability2ContainerBehaviour?.UseAbility(movementDirection, mousePosition, playerController);
    }
    



    //animation
    public virtual void PlayAtackAnimation()
    {
        animator.SetTrigger("Atack");
    }

    //UI
    protected void Awake()
    {
        CharacterUIBehaviour = Instantiate(characterUIPrefab,CharacterUIParent).GetComponent<CharacterUIBehaviour>();
    }
    protected void OnEnable()
    {
        characterUIBehaviour.gameObject.SetActive(true);
    }
    protected void OnDisable()
    {
        animator.SetTrigger("Idle");
        characterUIBehaviour.gameObject.SetActive(false);
    }
}
