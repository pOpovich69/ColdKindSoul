using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform ShotPoint;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform[] RandomPoints;

    private float offset;
    private float maxDelay;
    private float delay;
    private void Start()
    {
        offset = -90f;
        maxDelay = 1f;
        delay = maxDelay;
    }
    void Update()
    {
        if (Time.timeScale > 0)
        {
            GunLookOnMous();
            Shot();
        }
    }
    private void Shot()
    {
        if (delay <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                delay = maxDelay;
                TeleportToRandomPoint();
            }
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
    private void TeleportToRandomPoint()
    {
        int randomPoint = Random.Range(0, RandomPoints.Length);
        Player.transform.position = RandomPoints[randomPoint].position;
    }
    private void GunLookOnMous()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
    }
}
