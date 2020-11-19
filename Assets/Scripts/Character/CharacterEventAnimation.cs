using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventAnimation : MonoBehaviour
{
    public CharacterCombat combat;
    public void AttackEvent()
    {
        combat.AttackHit_AnimationEvent();
    }    
}
