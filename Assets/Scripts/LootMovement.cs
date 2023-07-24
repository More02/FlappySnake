using System;
using UnityEngine;

public class LootMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _followDuration = 0.5f;

    private bool _isFollowingTarget;
    private float _followTimer;

    private void Update()
    {
        if (!_isFollowingTarget)
        {
            var distance = _target.position - transform.position;
            if (!(distance.magnitude <= _detectionRadius)) return;

            var direction = (_target.position - transform.position).normalized;
            transform.position += direction * _movementSpeed * Time.deltaTime;
            
            _followTimer = _followDuration;
            _isFollowingTarget = true;
        }
        else
        {
            if (_followTimer > 0f)
            {
                var direction = (_target.position - transform.position).normalized;
                transform.position += direction * _movementSpeed * Time.deltaTime;
                _followTimer -= Time.deltaTime;
            }
            else
            {
                _isFollowingTarget = false;
            }
        }
    }
}

