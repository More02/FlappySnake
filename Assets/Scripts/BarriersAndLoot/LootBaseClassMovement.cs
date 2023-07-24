using UnityEngine;

namespace BarriersAndLoot
{
    /// <summary>
    /// Перемещение добычи
    /// </summary>
    public class LootBaseClassMovement : BarrierAndLootBaseClass
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _detectionRadius = 5f;
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _followDuration = 0.5f;

        private bool _isFollowingTarget;
        private float _followTimer;

        private void Start()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private void Update()
        {
            if (!isActiveAndEnabled) return;
            if (!_isFollowingTarget)
            {
                var distance = _target.position - transform.position;
                if (!(distance.magnitude <= _detectionRadius)) return;

                var transformVar = transform;
                var position = transformVar.position;
                
                var direction = (_target.position - position).normalized;
                position += direction * _movementSpeed * Time.deltaTime;
                transformVar.position = position;

                _followTimer = _followDuration;
                _isFollowingTarget = true;
            }
            else
            {
                if (_followTimer > 0f)
                {
                    var transformVar = transform;
                    var position = transformVar.position;
                    
                    var direction = (_target.position - position).normalized;
                    position += direction * _movementSpeed * Time.deltaTime;
                    transformVar.position = position;
                    _followTimer -= Time.deltaTime;
                }
                else
                {
                    _isFollowingTarget = false;
                }
            }
        }
    }
}

