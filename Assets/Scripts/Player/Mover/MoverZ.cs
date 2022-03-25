using UnityEngine;

public class MoverZ : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _movementZ;
    private float _offsetSpeed = 0.75f;
    private float _maxSpeed;
    private Vector3 _startPosition;
    public Vector3 StartPosition => _startPosition;

    private void Start()
    {
        _maxSpeed = _speed;
        _startPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _movementZ = new Vector3(Vector3.zero.x, Vector3.zero.y, _speed * Time.deltaTime);
        transform.Translate(_movementZ);
    }

    public bool CheckSpeedScalingAvailability()
    {
        return _speed - _offsetSpeed > 0 && _speed >= _maxSpeed;
    }

    public void ReduceSpeed()
    {
        _speed -= _offsetSpeed;
    }

    public void IncreaseSpeed()
    {
        _speed += _offsetSpeed;
    }

    public void EquateSpeed()
    {
        _speed = _maxSpeed;
    }
}

