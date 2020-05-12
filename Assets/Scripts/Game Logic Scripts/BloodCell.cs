using System;
using System.Collections;
using UnityEngine;

namespace Game_Logic_Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BloodCell : MonoBehaviour
    {
        public int lifePoints;
        private int _currentLifePoints;
        private CircleCollider2D _circleCollider;

        public void Start()
        {
            _currentLifePoints = lifePoints;
            _circleCollider = GetComponent<CircleCollider2D>();
        }
        
        void FixedUpdate()
        {
            print("Entra al script de blood cell");
            Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, _circleCollider.radius + 1.5f);
            foreach (var neighbor in neighbors)
            {
                string neighborTag = neighbor.tag;
                if (neighbor.tag.Contains("Virus"))
                {
                    print("Entra a receive Damage");
                    ReceiveDamage();                        
                }
            }
        }

        private void ReceiveDamage()
        {
            _currentLifePoints--;
            print(gameObject.name + " " + _currentLifePoints);
            if (_currentLifePoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}