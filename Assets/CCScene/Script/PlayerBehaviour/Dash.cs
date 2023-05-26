using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    public override void AbilityAction(Vector3 movementDirection, Vector3 mousePosition, Transform playerTransform, out bool canMove)
    {
        canMove = true;
        print("dashing!");
    }
}
