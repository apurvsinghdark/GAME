using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAnimation;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;
    public AnimatorOverrideController overrideController;

    protected CharacterCombat combat;
    [NonSerialized] public Animator animator;

    protected virtual void Start() {
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        if (overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaultAttackAnimSet;
        
        combat.OnAttack += OnAttack;
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
        int attackIndex = Random.Range(0,currentAttackAnimSet.Length);
        overrideController[replaceableAnimation.name] = currentAttackAnimSet[attackIndex];
    }
}
