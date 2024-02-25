using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] PlayerHearts;
    [SerializeField] private GameObject iceCube;
    [SerializeField] private GameObject lossPopup;
    //[SerializeField] private GameObject winPopup;
    private float maxSpeed;
    private float speed;
    private int health;

    private Rigidbody2D rb;
    private Animation anim;

    public bool IsFrozen { get; private set; }

    private int timeOfFrozen;
    private int maxTimeOfFrozen;

    private Animator animator;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        animator = GetComponentInChildren<Animator>();

        maxSpeed = 7f;
        speed = maxSpeed;
        health = 3;

        IsFrozen = false;
        maxTimeOfFrozen = 2;
        timeOfFrozen = maxTimeOfFrozen;
        iceCube.SetActive(IsFrozen);
    }

    void Update()
    {
        if (Time.timeScale > 0)
            Move();
    }
    public void Frozen()
    {
        StartCoroutine(FrozenRoutin());
    }
    public void GiveDamage()
    {
        health -= 1;
        DeactivatePlayerHeart(health);
        if (health <= 0)
        {
            Time.timeScale = 0f;
            lossPopup.SetActive(true);
        }
    }
    public void PlayAnimation(string animName)
    {
        anim.Play(animName);
    }
    private void Move()
    {
        float axisX = Input.GetAxis("H");
        float axisY = Input.GetAxis("V");
        rb.velocity = new Vector2(axisX * speed, axisY * speed);
    }
    private void DeactivatePlayerHeart(int heartNumber)
    {
        PlayerHearts[heartNumber].SetActive(false);
    }

    private IEnumerator FrozenRoutin()
    {
        animator.enabled = false;
        speed = 0f;
        SetBoolDataOnIceCube(true);
        while (timeOfFrozen > 0)
        {
            yield return new WaitForSeconds(1f);
            timeOfFrozen--;
        }
        animator.enabled = true;
        speed = maxSpeed;
        SetBoolDataOnIceCube(false);
        timeOfFrozen = maxTimeOfFrozen;
    }

    private void SetBoolDataOnIceCube(bool data)
    {
        IsFrozen = data;
        iceCube.SetActive(data);
    }
}
