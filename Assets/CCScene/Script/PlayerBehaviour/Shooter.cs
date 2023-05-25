using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Character
{
    //hability
    public override void Ability1(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove)
    {
        ability1ContainerBehaviour.UseAbility(movementDirection, mousePosition, playerTransform, out canMove);
    }
    public override void Ability2(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove)
    {
        ability2ContainerBehaviour.UseAbility(movementDirection, mousePosition, playerTransform, out canMove);
    }
    public override void EquipAbility1(GameObject ability)
    {
        mainCharacterAbility1ContainerBehaviour.EquipAbility(ability);
    }
    public override void EquipAbility2(GameObject ability)
    {
        mainCharacterAbility1ContainerBehaviour.EquipAbility(ability);
    }
    public override void UnequipAbility1()
    {
        mainCharacterAbility1ContainerBehaviour.UnequipAbility();
    }
    public override void UnequipAbility2()
    {
        mainCharacterAbility1ContainerBehaviour.UnequipAbility();
    }
}
