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
        if (Time.timeScale <= 0)
            return;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
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
                    Player player = col.gameObject.GetComponent<Player>();
                    Debug.Log(player);
                    player.Frozen();
                    Destroy(gameObject);
                    break;
                }

            default:
                Destroy(gameObject);
                break;
        }
    }
}
