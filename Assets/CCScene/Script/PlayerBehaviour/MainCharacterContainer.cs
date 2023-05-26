using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MainCharacterContainer : CharacterContainer
{
    [SerializeField] MainCharacter mainCharacter;


    public override void EquipCharacter(GameObject character, Transform CharacterUICanvas)
    {
        base.EquipCharacter(character, CharacterUICanvas);

        mainCharacter = this.character.GetComponent<MainCharacter>();
    }

    public void EquipAbility1(GameObject hability)
    {
        mainCharacter.EquipAbility1(hability);
    }
    public void EquipAbility2(GameObject hability)
    {
        mainCharacter.EquipAbility2(hability);
    }
    public void UnequipAbility1()
    {
        mainCharacter.UnequipAbility1();
    }
    public void UnequipAbility2()
    {
        mainCharacter.UnequipAbility2();
    }
}
