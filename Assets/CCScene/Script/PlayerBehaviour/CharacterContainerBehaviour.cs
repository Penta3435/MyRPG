using UnityEngine;


public class CharacterContainerBehaviour : MonoBehaviour
{
    public CharacterBehaviour characterBehaviour;

    #region character_container_behavour
    //character
    public void EquipCharacter(GameObject character)
    {
        //destroy all children
        transform.DestroyAllChildren();

        //instantiate character
        var instantiatedCharacter = Instantiate(character, transform);
        
        //setup character data
        characterBehaviour = instantiatedCharacter.GetComponent<CharacterBehaviour>();
    }
    public void UnequipCharacter()
    {

    }

    #endregion

    #region character_behaviour

    //weapon
    public void Atack()
    {
        characterBehaviour.Atack();
    }
    public void SwitchWeapon()
    {
        characterBehaviour.SwitchWeapon();
    }
    public void SwitchToMelee()
    {
        characterBehaviour.SwitchToMelee();
    }
    public void EquipWeapon(GameObject weapon)
    {
        characterBehaviour.EquipWeapon(weapon);
    }
    public void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        characterBehaviour.UnEquipWeapons(weaponContainer);
    }

    //hability
    public void Hability1()
    {
        characterBehaviour.Hability1();
    }
    public void Hability2()
    {
        characterBehaviour.Hability2();
    }
    public void EquipHability1(GameObject hability)
    {
        characterBehaviour.EquipHability1(hability);
    }
    public void EquipHability2(GameObject hability)
    {
        characterBehaviour.EquipHability2(hability);
    }
    public void UnequipHability1()
    {
        characterBehaviour.UnequipHability1();
    }
    public void UnequipHability2()
    {
        characterBehaviour.UnequipHability1();
    }
    #endregion

}
