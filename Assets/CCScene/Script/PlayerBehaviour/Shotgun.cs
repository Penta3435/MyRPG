using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangeWeapon
{
    [SerializeField] protected float randomness;
    protected override void WeaponAtackMethod()
    {
        if (canAtack)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Random.Range(-randomness, randomness), transform.rotation.eulerAngles.z));
            
            canAtack = false;
            Invoke("SetCanAtack", AnimatorController.animationClips[0].length / 2);
        }
    }
}
