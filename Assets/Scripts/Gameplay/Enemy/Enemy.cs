using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool IsFrozen { get; private set; }

    private float attackRadius;
    private float attackSpeed;
    private bool isAttack;
    private LayerMask playerMask;

    private float speed;
    private int timeOfFrozen;
    private int maxTimeOfFrozen;

    private Transform player;
    private GameObject iceCube;
    private Animator animator;

    private void Start()
    {
        speed = 2f;
        maxTimeOfFrozen = 10;
        timeOfFrozen = maxTimeOfFrozen;
        playerMask = LayerMask.GetMask("Player");
        isAttack = false;
        attackRadius = 1f;
        attackSpeed = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        iceCube = gameObject.transform.GetChild(0).gameObject;
        SetBoolDataOnIceCube(false);
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (IsFrozen || isAttack)
            return;
        Move();
        Attack();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    public void Frozen()
    {
        if (!IsFrozen)
        {
            StartCoroutine(FrozenRoutin());
        }
        else Destroy(gameObject);

    }
    private void Move()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }
    private void Attack()
    {
        Collider2D playerCol = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        if (playerCol != null)
        {
            StartCoroutine(AttackRoutin());
        }
    }
    private IEnumerator FrozenRoutin()
    {
        animator.speed = 0f;
        SetBoolDataOnIceCube(true);
        while (timeOfFrozen > 0)
        {
            yield return new WaitForSeconds(1f);
            timeOfFrozen--;
        }
        animator.speed = 1f;
        SetBoolDataOnIceCube(false);
        timeOfFrozen = maxTimeOfFrozen;
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
    private void SetBoolDataOnIceCube(bool data)
    {
        IsFrozen = data;
        iceCube.SetActive(data);
    }
}
