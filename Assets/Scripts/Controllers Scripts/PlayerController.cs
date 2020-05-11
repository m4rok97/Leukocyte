using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Range(0, 10)] public float moveSpeed = 2f;
        private Rigidbody2D _rigidbody;

        private Color[] _colors;
        private string[] _colorNames;
        private string _currentColorName;
        private int _currentColorIndex;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _colors = new[] {
                Color.white, 
                Color.yellow, 
                Color.green, 
                Color.yellow + Color.red};

            _colorNames = new string[]
            {
                "White",
                "Yellow",
                "Green",
                "Orange"
            };
            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _currentColorIndex = 0;
            _spriteRenderer.color = _colors[_currentColorIndex];
            _currentColorName = _colorNames[_currentColorIndex];
        }

        


        void Update()
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            Vector3 moveVelocity = moveInput.normalized * moveSpeed;
            _rigidbody.MovePosition(_rigidbody.position + ((Vector2)moveVelocity * Time.deltaTime));
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _currentColorIndex++;
                if (_currentColorIndex == _colors.Length)
                    _currentColorIndex = 0;
                
                _spriteRenderer.color = _colors[_currentColorIndex];
                _currentColorName = _colorNames[_currentColorIndex];
                tag = "Player " + _currentColorName;
            }
        }
    }
}