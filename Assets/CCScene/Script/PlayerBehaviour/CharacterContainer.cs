using JetBrains.Annotations;
using UnityEngine;


public class CharacterContainer : MonoBehaviour
{
    public Character character;//public for hand

    #region character_container_behavour
    //character
    public virtual void EquipCharacter(GameObject character, Transform CharacterUICanvas)
    {
        //destroy all children
        transform.DestroyAllChildren();

        //instantiate character
        GameObject characterInstance = Instantiate(character, transform);
        this.character = characterInstance.GetComponent<Character>();
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
    #endregion

}
