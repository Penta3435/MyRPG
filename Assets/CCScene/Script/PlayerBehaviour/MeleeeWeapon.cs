using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeeWeapon : Weapon
{
    [SerializeField] BoxCollider weaponTrigger;

    private void Awake()
    {
        WeaponAtack += () => weaponTrigger.enabled = true;
        WeaponAtacked += () => weaponTrigger.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        print("-hp");
    }
}
