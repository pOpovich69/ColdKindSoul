using Assets.Scripts.Gameplay.Enemy;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 20f;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy":
                {
                    col.gameObject.GetComponent<Enemy>().Frozen();
                    Destroy(gameObject);
                    break;
                }

            case "Player":
                {
                    col.gameObject.GetComponent<Player>().Frozen();
                    Destroy(gameObject);
                    break;
                }

            default:
                Destroy(gameObject);
                break;
        }
    }
}
