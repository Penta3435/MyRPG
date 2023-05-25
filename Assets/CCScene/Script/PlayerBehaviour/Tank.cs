using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Character
{

    public override void Ability1(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove) 
    {
        ability1ContainerBehaviour.UseAbility(movementDirection,mousePosition, playerTransform, out canMove);
    }
    public override void Ability2(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove) 
    {
        ability2ContainerBehaviour.UseAbility(movementDirection, mousePosition, playerTransform, out canMove);
    }
    public override void EquipAbility1(GameObject ability){}
    public override void EquipAbility2(GameObject ability){}
    public override void UnequipAbility1(){}
    public override void UnequipAbility2(){}

}
