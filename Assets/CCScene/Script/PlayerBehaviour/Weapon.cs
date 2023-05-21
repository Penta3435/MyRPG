using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public RuntimeAnimatorController animatorController;
    public WeaponType weaponType;

    public Action WeaponAtack;
    public Action WeaponAtacking;
    public Action WeaponAtacked;


}
