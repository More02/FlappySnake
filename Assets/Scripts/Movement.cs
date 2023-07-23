using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.2f;
    [SerializeField] public float _forwardSpeed = 5f;
    private float _tempJumpForce;
    private Rigidbody2D _rigidbody;
    private bool _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tempJumpForce = _jumpForce;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isJumping = true;
            Jump();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isJumping = false;
            _jumpForce = _tempJumpForce;
        }

        if (_isJumping)
        {
           // _jumpForce *= 5;
            Debug.Log(_jumpForce);
            Jump();
        }

        MoveForward();
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
    }

    private void MoveForward()
    {
        _rigidbody.velocity = new Vector2(_forwardSpeed, _rigidbody.velocity.y);
    }
}