using System.Collections;

using UnityEngine;

namespace Assets.Scripts.Gameplay.Enemy
{
    public class Enemy: MonoBehaviour
    {
        public bool IsFrozen { get; protected set; }

        protected float speed;
        protected float maxSpeed;

        protected float attackSpeed;

        protected int timeOfFrozen;
        protected int maxTimeOfFrozen;

        protected GameObject iceCube;
        protected Animator animator;
        protected Rigidbody2D rb;

        protected LayerMask playerMask;
        protected Transform player;

        protected virtual void BaseLogic()
        {
            if (IsFrozen || Time.timeScale <= 0)
                return;
            Move();
            Attack();
        }

        protected virtual void Move() { }

        protected virtual void Attack() { }

        public virtual void Frozen()
        {
            if (!IsFrozen)
            {
                StartCoroutine(FrozenRoutin());
            }
            else Destroy(gameObject);

        }

        protected IEnumerator FrozenRoutin()
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
            rb.velocity = Vector3.zero; 
        }

        protected void SetBoolDataOnIceCube(bool data)
        {
            IsFrozen = data;
            iceCube.SetActive(data);
        }

    }
}
