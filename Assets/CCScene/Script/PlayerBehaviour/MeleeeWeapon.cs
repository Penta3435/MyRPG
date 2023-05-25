using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeeWeapon : Weapon
{
    [SerializeField] BoxCollider weaponTrigger;

    protected override void WeaponAtackMethod()
    {
        if (weaponTrigger != null) weaponTrigger.enabled = true;
    }
    protected override void WeaponAtackedMethod()
    {
        if (weaponTrigger != null) weaponTrigger.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("-hp");
    }
    private void OnDisable()
    {
        weaponTrigger.enabled = false;
    }
}
