using UnityEngine;

namespace BaseMovement
{
    /// <summary>
    /// Перемещение персонажа
    /// </summary>
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 6f;
        [SerializeField] public float _forwardSpeed = 8f;
        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private bool _canStartProcesses;

        public delegate void OnInputEvent();
        public static event OnInputEvent OnSessionBegin;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        private void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (!_canStartProcesses))
            {
                _canStartProcesses = true;
                _rigidbody.constraints = RigidbodyConstraints2D.None;
                OnSessionBegin?.Invoke();
            }

            if (_canStartProcesses != true) return;

            if (Input.GetMouseButtonDown(0))
            {
                _isJumping = true;
                Jump();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isJumping = false;
            }

            if (_isJumping)
            {
                Jump();
            }

            MoveForward();
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }

        private void MoveForward()
        {
            _rigidbody.velocity = new Vector2(_forwardSpeed, _rigidbody.velocity.y);
        }
    }
}