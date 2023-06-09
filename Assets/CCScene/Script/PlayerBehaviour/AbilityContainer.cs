using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityContainer : MonoBehaviour
{
    protected Ability ability;
    public virtual void UseAbility(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController) 
    {
        if (transform.childCount == 1) ability.AbilityAction(movementDirection, mousePosition, playerController);
    }
}
