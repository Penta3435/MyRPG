using System.Threading;
using System;
using System.Collections;
using UnityEngine;

public class Dash : Ability
{
    [SerializeField] GameObject particle;

    Vector3 playerUseAbilityPosition;
    public override void AbilityAction(Vector3 movementDirection, Vector3 mousePosition, PlayerController playerController)
    {
        playerUseAbilityPosition = playerController.transform.position;
        StartCoroutine(DashAction(mousePosition, playerController));
    }

    float time;
    IEnumerator DashAction(Vector3 mousePosition, PlayerController playerController)
    {
        var particleGameObject = Instantiate(particle, transform);
        playerController.canMove = false;
        while (time <= 0.2f) 
        {
            time += Time.deltaTime;
            playerController.transform.position += (mousePosition - playerUseAbilityPosition).ZeroY().normalized * 60 * Time.deltaTime;
            yield return null; 
        }
        time = 0;
        playerController.canMove = true;
        Destroy(particleGameObject);
    }
}
