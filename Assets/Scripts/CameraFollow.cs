using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.125f; 

    private Vector3 _offset; 

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        var position = transform.position;
        var newPosition = new Vector3(_target.position.x + _offset.x, position.y, position.z);
        var smoothedPosition = Vector3.Lerp(position, newPosition, _speed * Time.deltaTime);
        position = smoothedPosition;
        transform.position = position;
    }
}
