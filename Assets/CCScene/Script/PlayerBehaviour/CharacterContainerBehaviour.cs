using JetBrains.Annotations;
using UnityEngine;


public class CharacterContainerBehaviour : MonoBehaviour
{
    public Character character;

    GameObject characterCanvas;

    #region character_container_behavour
    //character
    public void EquipCharacter(GameObject character, Transform CharacterUICanvas)
    {
        //destroy all children
        transform.DestroyAllChildren();

        //instantiate character
        this.character = Instantiate(character, transform).GetComponent<Character>();

        this.character.CharacterUIParent = CharacterUICanvas;
        this.character.gameObject.SetActive(true);
    }
    public void UnequipCharacter()
    {

    }

    #endregion

    #region character_behaviour

    //weapon
    public void Atack()
    {
        character.Atack();
    }
    public void SwitchWeapon()
    {
        character.SwitchWeapon();
    }
    public void SwitchToMelee()
    {
        character.SwitchToMelee();
    }
    public void EquipWeapon(GameObject weapon)
    {
        character.EquipWeapon(weapon);
    }
    public void UnEquipWeapons(WeaponContainer weaponContainer)
    {
        character.UnEquipWeapons(weaponContainer);
    }

    //hability
    public void Ability1(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove)
    {
        character.Ability1(movementDirection, mousePosition, playerTransform, out canMove);
    }
    public void Ability2(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove)
    {
        character.Ability2(movementDirection, mousePosition, playerTransform, out canMove);
    }
    public void EquipAbility1(GameObject hability)
    {
        character.EquipAbility1(hability);
    }
    public void EquipAbility2(GameObject hability)
    {
        character.EquipAbility2(hability);
    }
    public void UnequipAbility1()
    {
        character.UnequipAbility1();
    }
    public void UnequipAbility2()
    {
        character.UnequipAbility1();
    }
    #endregion

}
