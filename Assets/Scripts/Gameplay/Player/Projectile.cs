using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float lifeTime;
    void Start()
    {
        speed = 20f;
        lifeTime = 1f;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Frozen();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
