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
        public bool isRegenerative;
        private float _nextRegenerateTime;
        [Range(1,10)]public int secondsBetweenRegenerate = 5;
        [Range(1, 50)]public int regenerateAmount = 10;
        
        public void Start()
        {
            _currentLifePoints = lifePoints;
            _circleCollider = GetComponent<CircleCollider2D>();
        }

        public void OnEnable()
        {
            _gameController = FindObjectOfType<GameController>();
        }

        void Update()
        {
            if (isRegenerative && Time.time > _nextRegenerateTime)
            {
                    Regenerate(regenerateAmount);
                    _nextRegenerateTime = Time.time + secondsBetweenRegenerate;
            }
        }

        void Regenerate(int incLifePoints)
        {
            _currentLifePoints = Math.Min(_currentLifePoints + incLifePoints, lifePoints);
            print("LP: " + _currentLifePoints);
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