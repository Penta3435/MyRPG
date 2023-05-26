using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    [SerializeField] MainCharacterAbilityContainer mainCharacterAbility1Container;
    [SerializeField] MainCharacterAbilityContainer mainCharacterAbility2Container;

    public void EquipAbility1(GameObject ability) => mainCharacterAbility1Container.EquipAbility(ability);
    public void EquipAbility2(GameObject ability) => mainCharacterAbility2Container?.EquipAbility(ability);
    public void UnequipAbility1() => mainCharacterAbility1Container.UnequipAbility();
    public void UnequipAbility2() => mainCharacterAbility2Container?.UnequipAbility();
}
