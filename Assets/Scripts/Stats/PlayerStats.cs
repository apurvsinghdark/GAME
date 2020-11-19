using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Start() {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Weapon newItem, Weapon oldItem)
    {
        if (newItem != null)
        {
            damage.AddModifiers(newItem.damageModifier);
        }
        if (oldItem != null)
        {
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }
    // void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    // {
    //     if (newItem)
    //     {
    //         armor.AddModifiers(newItem.armorModifier);
    //     }
    //     if (newItem)
    //     {
    //         armor.RemoveModifier(oldItem.armorModifier);
    //     }
    // }
    
    public override void Die()
    {
        base.Die();
        GameManager.instance.KillPlayer();
    }

}
