using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{ 
    public WeaponAnimation[] weaponAnimations;
    Dictionary<Weapon, AnimationClip[]> weaponAnimationDict;
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        weaponAnimationDict = new Dictionary<Weapon, AnimationClip[]>();

        foreach (WeaponAnimation a in weaponAnimations)
        {
            weaponAnimationDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Weapon newItem, Weapon oldItem)
    {
        if (newItem != null && newItem.weapon == WeaponID.Axe)
        {
            if(weaponAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationDict[newItem];
            }
        }
        if (newItem != null && newItem.weapon == WeaponID.Hammer)
        {
            if(weaponAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationDict[newItem];
            }
        }
        if (newItem != null && newItem.weapon == WeaponID.Throwable)
        {
            if(weaponAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationDict[newItem];
            }
        }
        if (newItem == null && oldItem != null)
        {
            currentAttackAnimSet = defaultAttackAnimSet;
        }
        // if (newItem != null && newItem.weapon == WeaponID.Sword)
        // {
            // if(weaponAnimationDict.ContainsKey(newItem))
            // {
                // currentAttackAnimSet = weaponAnimationDict[newItem];
            // }
        // }
        // if (newItem == null && oldItem != null && oldItem.weapon == WeaponID.Sword)
        // {
            // 
            // currentAttackAnimSet = defaultAttackAnimSet;
            // 
        // }
        // if (newItem == null && oldItem != null && oldItem.weapon == WeaponID.Axe)
        // {
        //     currentAttackAnimSet = defaultAttackAnimSet;
        // }
    }
}

[System.Serializable]
public struct WeaponAnimation{
    public Weapon weapon;
    public AnimationClip[] clips;
}