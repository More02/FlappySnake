using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] public float _forwardSpeed = 2f;
    private Rigidbody2D _rigidbody;
    private bool _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        }

        if (_isJumping)
        {
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