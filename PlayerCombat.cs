using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attack;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 15;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

      Collider2D[] hittEnemies = Physics2D.OverlapCircleAll(attack.position,attackRange, enemyLayers);

        foreach(Collider2D enemy in hittEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
