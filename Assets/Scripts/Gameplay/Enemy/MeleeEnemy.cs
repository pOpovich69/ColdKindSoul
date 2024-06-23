using Assets.Scripts.Gameplay.Enemy;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    private float attackRadius;
    private bool isAttack;


    private void Start()
    {
        maxSpeed = 2f;
        speed = maxSpeed;

        maxTimeOfFrozen = 10;
        timeOfFrozen = maxTimeOfFrozen;

        isAttack = false;
        attackRadius = 1f;
        attackSpeed = 0.5f;

        playerMask = LayerMask.GetMask("Player");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        iceCube = gameObject.transform.GetChild(0).gameObject;
        SetBoolDataOnIceCube(false);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isAttack)
            return;
        BaseLogic();
    }
    protected override void Move()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += speed * Time.deltaTime * direction;
    }
    protected override void Attack()
    {
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        if (playerCol != null)
        {
            StartCoroutine(AttackRoutin());
        }
    }

    private IEnumerator AttackRoutin()
    {
        isAttack = true;
        yield return new WaitForSeconds(attackSpeed);
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        if (playerCol != null)
        {
            playerCol.GetComponent<Player>().GiveDamage();
        }
        isAttack = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
