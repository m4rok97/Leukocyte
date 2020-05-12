using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Game_Logic_Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(FlockAgent))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Virus : MonoBehaviour
    {
        public string color;
        public int lifePoints;
        private int _currentLifePoints;
        private CircleCollider2D _circleCollider;
        private FlockAgent _flockAgent;
        private bool _isAlife;
        
        void Start()
        {
            _currentLifePoints = lifePoints;
            _circleCollider = GetComponent<CircleCollider2D>();
            _flockAgent = GetComponent<FlockAgent>();
            _isAlife = true;
        }

        void FixedUpdate()
        {
            Collider2D[] neighbors = Physics2D.OverlapCircleAll(transform.position, _circleCollider.radius);
            foreach (var neighbor in neighbors)
            {
                Leukocyte leukocyte = neighbor.GetComponent<Leukocyte>(); 
                if ( !(leukocyte is null))
                {
                    ReceiveDamage(leukocyte);                        
                }
            }
        }

        private void ReceiveDamage (Leukocyte leukocyte)
        {
            int damage = leukocyte.CurrentColorName == color ? 3 : 1;
            _currentLifePoints -= damage;
            
            if (_currentLifePoints <= 0)
            {
                Die(leukocyte);
            }
        }

        private void Die(Leukocyte killer)
        {
            _isAlife = false;
            killer.ChangeColor(color);
            _flockAgent.RemoveFromFlock();
            Destroy(gameObject);
        }
    }
}
