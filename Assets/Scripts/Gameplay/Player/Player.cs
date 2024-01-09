using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] PlayerHearts;

    private float speed;
    private int health;

    private Rigidbody2D rb;
    private Animation anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        speed = 7f;
        health = 3;
    }

    void Update()
    {
        Move();
    }
    public void GiveDamage()
    {
        health -= 1;
        DeactivatePlayerHeart(health);
        if (health <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("You lose!");
        }
    }
    public void PlayAnimation(string animName)
    {
        GetComponent<Animation>().Play(animName);
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
}
