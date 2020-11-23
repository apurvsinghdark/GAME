using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : CharacterAnimator
{
    public NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speedPercent, 0.01f , Time.deltaTime);

        //animator.SetBool("inCombat", combat.InCombat);
    }
}

