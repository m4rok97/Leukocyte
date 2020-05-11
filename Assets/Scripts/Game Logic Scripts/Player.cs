using UnityEngine;

namespace Game_Logic_Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
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
                Color.magenta,
            };

            _colorNames = new string[]
            {
                "White",
                "Yellow",
                "Green",
                "Orange",
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
