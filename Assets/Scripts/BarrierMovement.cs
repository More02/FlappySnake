using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrierMovement : MonoBehaviour
{
    private float _timerToChange;
    private float _changeDirectionInterval;
    private Rigidbody2D _rigidbody;
    private float _previousVelocityY;

    private void Start()
    {
        //if (!isActiveAndEnabled) return;
        _timerToChange = 0f;
        _changeDirectionInterval = Random.Range(0.5f, 1f);
        _rigidbody = GetComponent<Rigidbody2D>();
        SetVelocity();
        StartCoroutine(BarrierCoroutine());
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator BarrierCoroutine()
    {
        _timerToChange += Time.deltaTime;
        if (_timerToChange < _changeDirectionInterval) yield break;

        ChangeDirection();
        _changeDirectionInterval = Random.Range(1f, 3f);
        _timerToChange = 0f;
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void ChangeDirection()
    {
        _previousVelocityY *= -1;
        _rigidbody.velocity = new Vector2(0f, _previousVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Border"))
        {
            ChangeDirection();
        }
    }

    private void SetVelocity()
    {
        var randomYDirection = Random.Range(-1f, 1f) > 0 ? 1 : -1;
        var randomDirection = new Vector2(0f, randomYDirection);
        _rigidbody.velocity = randomDirection * Random.Range(1f, 3f);
        _previousVelocityY = _rigidbody.velocity.y;
    }
}