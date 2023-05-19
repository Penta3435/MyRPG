using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;

    public virtual void WeaponAtackMethod() { }
    public virtual void WeaponAtackingMethod() { }
    public virtual void WeaponAtackedMethod() { }


}
