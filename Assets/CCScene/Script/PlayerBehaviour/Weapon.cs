using System;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Sprite weaponSprite;
    [SerializeField] protected RuntimeAnimatorController animatorController;
    [SerializeField] protected WeaponType weaponType;
    
    [SerializeField] protected Action weaponAtack;
    [SerializeField] protected Action weaponAtacking;
    [SerializeField] protected Action weaponAtacked;


    public Sprite WeaponSprite { get => weaponSprite; }
    public RuntimeAnimatorController AnimatorController { get => animatorController;  }
    public WeaponType WeaponType { get => weaponType; }
    public Action WeaponAtack { get => weaponAtack; }
    public Action WeaponAtacking { get => weaponAtacking; }
    public Action WeaponAtacked { get => weaponAtacked; }

    private void Awake()
    {
        weaponAtack += WeaponAtackMethod;
        weaponAtacking += WeaponAtackingMethod;
        weaponAtacked += WeaponAtackedMethod;
    }
    protected virtual void WeaponAtackMethod() { }
    protected virtual void WeaponAtackedMethod() { }
    protected virtual void WeaponAtackingMethod() { }

}
