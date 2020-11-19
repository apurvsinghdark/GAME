using UnityEngine;

[CreateAssetMenu(fileName ="New Food", menuName = "Inventory/Food")]
public class Food : Item
{
    public FoodItem foodItem;
    public int healthModifier;

    public override void Use()
    {
        base.Use();

        FoodManager.instance.OnHeal(this);        
        RemoveFromInventory();
    }
}

public enum FoodItem{ melon, apple, banana }
