using UnityEngine;

public class MainCharacterAbilityContainer : AbilityContainer
{
    public void EquipAbility(GameObject ability)
    {
        UnequipAbility();
        this.ability = Instantiate(ability, transform).GetComponent<Ability>();
    }
    public void UnequipAbility() 
    {
        transform.DestroyAllChildren();
        ability = null;
    }
}
