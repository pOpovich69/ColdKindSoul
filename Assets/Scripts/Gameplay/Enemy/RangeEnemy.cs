using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts.Gameplay.Enemy
{
    class RangeEnemy: Enemy
    {
        [SerializeField] private GameObject Projectile;
        [SerializeField] private Transform ShotPoint;

        private float offset;

        private float maxDelay;
        private float delay;

        private void Start()
        {
            offset = -90f;
            maxDelay = 2f;
            delay = maxDelay;

            maxTimeOfFrozen = 10;
            timeOfFrozen = maxTimeOfFrozen;

            playerMask = LayerMask.GetMask("Player");
            player = GameObject.FindGameObjectWithTag("Player").transform;

            iceCube = gameObject.transform.GetChild(0).gameObject;
            SetBoolDataOnIceCube(false);

            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            BaseLogic();
        }

        protected override void Attack()
        {
            LookOnPlayer();
            Shot();
        }

        private void Shot()
        {
            if (delay <= 0f && !player.GetComponent<Player>().IsFrozen)
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                delay = maxDelay;
            }
            else
            {
                delay -= Time.deltaTime;
            }
        }

        private void LookOnPlayer()
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
        }

    }
}
