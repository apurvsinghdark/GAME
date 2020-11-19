using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Add Nav Mesh

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackDelay = 2f;
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    [SerializeField] float rayDistance = 2f;
    public bool InCombat { get; private set; }

    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats target;

    [SerializeField] LayerMask layer;

    private void Start() {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update() {

        if(EventSystem.current.IsPointerOverGameObject())
            return;

        Attack();
        
        attackCoolDown -= Time.deltaTime;

        RaycastHit hit;
        bool ray = Physics.Raycast(transform.position + new Vector3(0,1,0), transform.forward , out hit, rayDistance, layer);
        
        if (ray)
        {
            EnemyStats enemyStats = hit.collider.GetComponent<EnemyStats>();

            print(hit.transform.name);
            target = enemyStats;
        }
        else{
            return;
        }
    }

    private void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (attackCoolDown <= 0f)
            {
                StartCoroutine(AttackOn());
                attackCoolDown = 1f/attackSpeed;
            }
        }
    }

    IEnumerator AttackOn()
    {
        yield return new WaitForSeconds(attackDelay);
        
        if(OnAttack != null)
            OnAttack();
    }

    public void AttackHit_AnimationEvent()
    {
        if(target != null)
            target.TakeDamage(myStats.damage.GetValue());
        else
            return;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0,1,0), transform.forward * rayDistance);
    }
}
