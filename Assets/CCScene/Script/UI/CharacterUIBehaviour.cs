using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIBehaviour : MonoBehaviour
{
    [SerializeField] protected Image hability1Image;
    [SerializeField] protected Image hability2Image;
    [SerializeField] protected Image pasiveImage;
    [SerializeField] protected Image weapon1Image;
    [SerializeField] protected Image weapon2Image;
    [SerializeField] protected Image meleeWeaponImage;
    [SerializeField] protected GameObject weapon1Mask;
    [SerializeField] protected GameObject weapon2Mask;
    [SerializeField] protected GameObject meleeWeaponMask;

    public Sprite Hability1Image { set { if(hability1Image != null) 
                hability1Image.sprite = value; } }
    public Sprite Hability2Image { set { if(hability2Image != null) 
                hability2Image.sprite = value; } }
    public Sprite PasiveImage { set { if (pasiveImage != null) 
                pasiveImage.sprite = value; } }
    public Sprite Weapon1Image { set { if (weapon1Image != null)
                weapon1Image.sprite = value; } }
    public Sprite Weapon2Image { set { if (weapon2Image != null)
                weapon2Image.sprite = value; } }
    public Sprite MeleeWeaponImage { set { if (meleeWeaponImage != null)
                meleeWeaponImage.sprite = value; } }

    public void EnableWeapon1() 
    { 
        if (weapon1Mask != null) weapon1Mask.SetActive(false);
        DisableWeapon2();
        DisableMeleeWeapon();
    }
    public void EnableWeapon2() 
    { 
        if (weapon2Mask != null) weapon2Mask.SetActive(false);
        DisableWeapon1();
        DisableMeleeWeapon();
    }
    public void EnableMeleeWeapon() 
    { 
        if (meleeWeaponMask != null) meleeWeaponMask.SetActive(false);
        DisableWeapon1();
        DisableWeapon2();
    }
    public void DisableWeapon1() { if (weapon1Mask != null) weapon1Mask.SetActive(true); }
    public void DisableWeapon2() { if (weapon2Mask != null) weapon2Mask.SetActive(true); }
    public void DisableMeleeWeapon() { if (meleeWeaponMask != null) meleeWeaponMask.SetActive(true); }
}