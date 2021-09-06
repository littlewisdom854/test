using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;
    private SpriteRenderer sp;

    private Animator anim;
    public GameObject projectile;
    public Transform firePoint;
    private Transform target;


    private void Start()
    {
        wayPointTarget = wayPoint01;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            anim.SetBool("op_attack", false);
            Patrol();
        }
        else
        {
            anim.SetBool("op_attack", true);
        }

       
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint01.position) <= 0.01f)
        {
            wayPointTarget = wayPoint02;

            sp.flipX = true;
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }

        if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.01f)
        {
            wayPointTarget = wayPoint01;

            sp.flipX = true;
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }
    }

   
    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
