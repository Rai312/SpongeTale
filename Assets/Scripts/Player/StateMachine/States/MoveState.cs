using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Transformable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CinemachineSwitcher))]
public class MoveState : State
{
    [SerializeField] private PointFollowCamera _pointFollowCamera;
    [SerializeField] private ConfigurableJoint _configurableJoint;
    [SerializeField] private ConfigurableJoint _configurableJointChild;
    [SerializeField] private TrailBrush _trailBrush;
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigidbody;
    private Vector3 _force;
    private Transformable _transformable;
    private CinemachineSwitcher _cinemaSwitcher;

    private void Awake()
    {
        _transformable = GetComponent<Transformable>();
        _cinemaSwitcher = GetComponent<CinemachineSwitcher>();
    }

    private void OnEnable()
    {
        _cinemaSwitcher.SwitchCamera(_cinemaSwitcher.IsPlaying);

        _trailBrush.gameObject.SetActive(true);
        _pointFollowCamera.enabled = true;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = false;

        _transformable.MoveToMovingPosition();
        _transformable.MoveToMovingRotation();

        _joystick.AxisOptions = AxisOptions.Horizontal;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _force = Vector3.zero;

        TrySetNextPositionX();
        TrySetNextPositionY();

        _rigidbody.velocity = _force * _speed;
    }

    private void TrySetNextPositionX()
    {
        if (_joystick.Direction.x > 0)
            _force.x = _joystick.Direction.x;
        else if (_joystick.Direction.x < 0)
            _force.x = _joystick.Direction.x;
    }

    private void TrySetNextPositionY()
    {
        if (_joystick.Direction.y > 0)
            _force.y = _joystick.Direction.y;
        else if (_joystick.Direction.y < 0)
            _force.y = _joystick.Direction.y;
    }
}

