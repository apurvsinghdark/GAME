using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;

    private void Awake() {
        if(instance == null)
            instance = this;
    }
    public CharacterStats myStats;

    public void OnHeal(Food food)
    {
        if(food != null)
            myStats.TakeHeal(food.healthModifier);
    }
}
