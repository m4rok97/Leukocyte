using System;
using System.Collections;
using Controllers_Scripts;
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
        private GameController _gameController;

        public void Start()
        {
            _currentLifePoints = lifePoints;
            _circleCollider = GetComponent<CircleCollider2D>();
            _gameController = FindObjectOfType<GameController>();
        }
        
        void FixedUpdate()
        {
            Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, _circleCollider.radius + 1.5f);
            foreach (var neighbor in neighbors)
            {
                string neighborTag = neighbor.tag;
                if (neighbor.tag.Contains("Virus"))
                {
                    ReceiveDamage();                        
                }
            }
        }

        private void ReceiveDamage()
        {
            _currentLifePoints--;
            if (_currentLifePoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _gameController.RemoveBloodCell(this);
            Destroy(gameObject);
        }
    }
}