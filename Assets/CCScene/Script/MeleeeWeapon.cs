using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeeWeapon : Weapon
{
    [SerializeField] BoxCollider weaponTrigger;
    public override void WeaponAtackMethod()
    {
        weaponTrigger.enabled = true;
    }
    public override void WeaponAtackedMethod()
    {
        weaponTrigger.enabled = false;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        print("-hp");
    }
}
