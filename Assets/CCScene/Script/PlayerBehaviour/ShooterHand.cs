using UnityEngine;

public class ShooterHand : Hand
{
    [SerializeField] Transform weapon2Container;
    [SerializeField] Weapon weapon2;

    public override void WeaponAtack()
    {
        currentWeapon.WeaponAtack();
    }
    public override void WeaponAtacking()
    {

    }
    public override void WeaponAtacked()
    {
        
    }
    public override Weapon EquipWeapon(GameObject weapon, out bool used)
    {
        WeaponType weaponType = weapon.GetComponent<Weapon>().WeaponType;
        used = false;

        if(weaponType != WeaponType.ShooterMelee && weaponType != WeaponType.ShooterRange)
        {
            return null;
        }

        WeaponContainer weaponContainer;

        if(weaponType == WeaponType.ShooterMelee)
        {
            weaponContainer = WeaponContainer.MeleeWeaponContainer;
        }
        else if (weapon1Container.childCount == 0)
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }
        else if (weapon2Container.childCount == 0)
        {
            weaponContainer = WeaponContainer.Weapon2Container;
        }
        else if (weapon1Container.gameObject.activeSelf == true)
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }
        else if (weapon2Container.gameObject.activeSelf == true)
        {
            weaponContainer = WeaponContainer.Weapon2Container;
        }
        else
        {
            weaponContainer = WeaponContainer.Weapon1Container;
        }


        UnequipWeapon(weaponContainer);
        EquipWeaponIn(weaponContainer);


        if(meleeWeaponContainer.gameObject.activeSelf == true)
        {
            UseWeapon(weaponContainer, out used);
            used = true;
        }
        else if (weapon1Container.gameObject.activeSelf)
        {
            currentWeapon = weapon1;
        }
        else if (weapon2Container.gameObject.activeSelf)
        {
            currentWeapon = weapon2;
        }

        return currentWeapon;

        void EquipWeaponIn(WeaponContainer weaponContainer)
        {
            if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
            {
                GameObject weaponInstance = Instantiate(weapon, meleeWeaponContainer);
                meleeWeapon = weaponInstance.GetComponent<Weapon>();
                characterUIBehaviour.MeleeWeaponImage = meleeWeapon.WeaponSprite;
            }
            else if(weaponContainer == WeaponContainer.Weapon1Container)
            {
                GameObject weaponInstance = Instantiate(weapon, weapon1Container);
                weapon1 = weaponInstance.GetComponent<Weapon>();
                characterUIBehaviour.Weapon1Image = weapon1.WeaponSprite;
            }
            else
            {
                GameObject weaponInstance = Instantiate(weapon, weapon2Container);
                weapon2 = weaponInstance.GetComponent<Weapon>();
                characterUIBehaviour.Weapon2Image = weapon2.WeaponSprite;
            }
        }
    }
    public override void UnequipWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer)
        {
            meleeWeaponContainer.DestroyAllChildren();

            meleeWeapon = null;
        }
        else if(weaponContainer == WeaponContainer.Weapon1Container)
        {
            weapon1Container.DestroyAllChildren();

            weapon1 = null;
        }
        else
        {
            weapon2Container.DestroyAllChildren();

            weapon2 = null;
        }
    }
    public override Weapon UseWeapon(WeaponContainer weaponContainer, out bool used)
    {
        if (weaponContainer == WeaponContainer.MeleeWeaponContainer && meleeWeaponContainer.childCount != 0 && currentWeapon != meleeWeapon)
        {
            currentWeapon = meleeWeapon;

            meleeWeaponContainer.gameObject.SetActive(true);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(false);

            used = true;
        }
        else if (weaponContainer == WeaponContainer.Weapon1Container && weapon1Container.childCount != 0 && currentWeapon != weapon1Container)
        {
            currentWeapon = weapon1;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(true);
            weapon2Container.gameObject.SetActive(false);

            used = true;
        }
        else if (weaponContainer == WeaponContainer.Weapon2Container && weapon2Container.childCount != 0 && currentWeapon != weapon2Container)
        {
            currentWeapon = weapon2;

            meleeWeaponContainer.gameObject.SetActive(false);
            weapon1Container.gameObject.SetActive(false);
            weapon2Container.gameObject.SetActive(true);

            used = true;
        }
        else used = false;

        UpdateUI();
        return currentWeapon;
    }
    public override Weapon SwitchWeapon(out bool switched)
    {
        if (weapon1Container.gameObject.activeSelf == true && weapon2Container.childCount == 1)
        {
            //weapon1Container.gameObject.SetActive(false);
            //weapon2Container.gameObject.SetActive(true);
            //meleeWeaponContainer.gameObject.SetActive(false);

            //currentWeapon = weapon2;
            UseWeapon(WeaponContainer.Weapon2Container, out switched);
        }
        else if (weapon2Container.gameObject.activeSelf == true && weapon1Container.childCount == 1)
        {
            //weapon1Container.gameObject.SetActive(true);
            //weapon2Container.gameObject.SetActive(false);
            //meleeWeaponContainer.gameObject.SetActive(false);

            //currentWeapon = weapon1;

            UseWeapon(WeaponContainer.Weapon1Container, out switched);
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == true && weapon1Container.childCount == 1)
        {
            //weapon1Container.gameObject.SetActive(true);
            //weapon2Container.gameObject.SetActive(false);
            //meleeWeaponContainer.gameObject.SetActive(false);

            //currentWeapon = weapon1;
            UseWeapon(WeaponContainer.Weapon1Container, out switched);
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == true && weapon2Container.childCount == 1)
        {
            //weapon1Container.gameObject.SetActive(false);
            //weapon2Container.gameObject.SetActive(true);
            //meleeWeaponContainer.gameObject.SetActive(false);

            //currentWeapon = weapon2;
            UseWeapon(WeaponContainer.Weapon2Container, out switched);
        }
        else if (meleeWeaponContainer.gameObject.activeSelf == false)
        {
            //weapon1Container.gameObject.SetActive(false);
            //weapon2Container.gameObject.SetActive(false);
            //meleeWeaponContainer.gameObject.SetActive(true);

            //currentWeapon = meleeWeapon;
            UseWeapon(WeaponContainer.MeleeWeaponContainer, out switched);
        }
        else switched = false;

        return currentWeapon;
    }
    protected override void UpdateUI()
    {
        if (weapon1Container.gameObject.activeSelf == true) characterUIBehaviour.EnableWeapon1();
        else if(weapon2Container.gameObject.activeSelf == true) characterUIBehaviour.EnableWeapon2();
        else if(meleeWeaponContainer.gameObject.activeSelf == true) characterUIBehaviour.EnableMeleeWeapon();
    }
}
