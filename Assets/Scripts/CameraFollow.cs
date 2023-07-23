using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset; 

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        var transformVar = transform;
        var position = transformVar.position;
        var newPosition = new Vector3(_target.position.x + _offset.x, position.y, position.z);
        transformVar.position = newPosition;
    }
}
