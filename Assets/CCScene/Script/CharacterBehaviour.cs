using UnityEngine;


public class CharacterBehaviour : MonoBehaviour
{
    Animator animator;

    //characterProperties
    private Transform rightHand;
    private Transform leftHand;
    private Transform hability1Container;
    private Transform hability2Container;
    private WeaponData weaponData;

    #region ACTION

    #region character_container_behavour
    //character
    public void EquipCharacter(GameObject character)
    {
        //destroy all children
        DestroyAllChildren(transform);

        //instantiate character
        var instantiatedCharacter = Instantiate(character, transform);
        
        //setup character data
        CharacterData characterData = instantiatedCharacter.GetComponent<CharacterData>();
        leftHand = characterData.leftHand;
        rightHand = characterData.rightHand;
        hability1Container = characterData.Hability1Container;
        hability2Container = characterData.Hability2Container;
        animator = characterData.characterAnimator;
    }
    public void UnequipCharacter()
    {

    }

    #endregion

    #region character_behaviour
    //weapon
    public void Atack()
    {
        weaponData.WeaponAtackMethod();
    }
    public void SwitchWeapon()
    {

    }
    public void EquipWeapon(GameObject weapon)
    {
        DestroyAllChildren(rightHand);
        UnsetWeaponAnimation();

        var weaponInstance = Instantiate(weapon, rightHand);

        weaponData = weaponInstance.GetComponent<WeaponData>();
        SetWeaponAnimation(weaponData.weaponType);
    }
    public void UnEquipWeapon()
    {

        rightHand.DetachChildren();
        leftHand.DetachChildren();
    }

    //hability
    public void Hability1()
    {
        
    }
    public void Hability2()
    {
        
    }
    public void EquipHability1(GameObject hability)
    {

    }
    public void EquipHability2(GameObject hability)
    {

    }
    public void UnequipHability1()
    {

    }
    public void UnequipHability2()
    {

    }
    #endregion

    #endregion


    #region ANIMATION
    void SetWeaponAnimation(WeaponType weaponType)
    {
        animator.SetLayerWeight((int)weaponType, 1);
    }
    private void UnsetWeaponAnimation()
    {
        if (weaponData == null) return;
        animator.SetLayerWeight((int)weaponData.weaponType, 0);
    }
    public void PlayAtackAnimation()
    {
        animator.SetTrigger("Atack");
    }
    #endregion


    //internal method
    private void DestroyAllChildren(Transform parent)
    {
        if (parent.childCount != 0)
        {
            for (int childNum = 0; childNum < parent.childCount; childNum++)
            {
                Destroy(parent.GetChild(childNum).gameObject);
            }
        }
    }
}
