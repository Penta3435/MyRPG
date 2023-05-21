using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] GameObject bulletPrefab;

    public void Awake() {
        WeaponAtack += () => Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
