using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Transform CharacterUIParent { protected get; set; }
    public Transform Hand { get => hand; }

    [SerializeField] protected Transform hand;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Hand rightHandBehaviour;
    [SerializeField] protected AbilityContainer ability1ContainerBehaviour;
    [SerializeField] protected AbilityContainer ability2ContainerBehaviour;
    [SerializeField] protected MainCharacterAbilityContainer mainCharacterAbility1ContainerBehaviour;
    [SerializeField] protected MainCharacterAbilityContainer mainCharacterAbility2ContainerBehaviour;
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
        animator.SetTrigger("Idle");
        var animatorController = rightHandBehaviour.SwitchWeapon();
        animator.runtimeAnimatorController = animatorController.AnimatorController;
    }
    public virtual void SwitchToMelee()
    {
        animator.SetTrigger("Idle");
        var animatorController = rightHandBehaviour.UseWeapon(WeaponContainer.MeleeWeaponContainer);
        animator.runtimeAnimatorController = animatorController.AnimatorController;
    }
    public virtual void EquipWeapon(GameObject weapon)
    {
        var weaponComponent = rightHandBehaviour.EquipWeapon(weapon);
        if (weaponComponent != null) animator.runtimeAnimatorController = weaponComponent.AnimatorController;
    }
    public virtual void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        rightHandBehaviour.UnequipWeapon(weaponContainer);
    }

    //hability
    public abstract void Ability1(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove);
    public abstract void Ability2(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove);
    public abstract void EquipAbility1(GameObject ability);
    public abstract void EquipAbility2(GameObject ability);
    public abstract void UnequipAbility1();
    public abstract void UnequipAbility2();



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
