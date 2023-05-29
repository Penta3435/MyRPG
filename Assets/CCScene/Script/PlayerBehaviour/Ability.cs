using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]public Sprite abilitySprite;

    public abstract void AbilityAction(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController);
    //public abstract IEnumerator AbilityAction(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController);

}
