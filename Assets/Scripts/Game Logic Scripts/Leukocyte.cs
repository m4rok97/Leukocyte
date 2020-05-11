using System;
using UnityEngine;

namespace Game_Logic_Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(FlockAgent))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Leukocyte : MonoBehaviour
    {
        private string _currentColorName;
        private SpriteRenderer _spriteRenderer;
        public string CurrentColorName => _currentColorName;

        public void ChangeColor(string color)
        {
            switch (color)
            {
                case "Yellow":
                    _spriteRenderer.color = Color.yellow;
                    _currentColorName = "Yellow";
                    break;
                case "Green":
                    _spriteRenderer.color = Color.green;
                    _currentColorName = "Green";
                    break;
                case "Orange":
                    _spriteRenderer.color = Color.magenta;
                    _currentColorName = "Orange";
                    break;
                default:
                    _spriteRenderer.color = Color.white;
                    _currentColorName = "White";
                    break;
            }

            tag = "Player " + _currentColorName;
        }

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentColorName = "White";
        }

        void Update()
        {
        }
    }
}