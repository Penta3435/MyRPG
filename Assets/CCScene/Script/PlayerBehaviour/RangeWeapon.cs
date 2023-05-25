using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField]protected GameObject bulletPrefab;

    protected bool canAtack = true;
    protected override void WeaponAtackMethod()
    {
        if (canAtack)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            canAtack = false;
            Invoke("SetCanAtack", AnimatorController.animationClips[0].length / 2);
        }
    }
    protected virtual void SetCanAtack() => canAtack = true;
}
