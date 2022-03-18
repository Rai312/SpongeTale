using UnityEngine;
using DG.Tweening;
using System;

namespace SpongeTale
{
    [RequireComponent(typeof(Transformable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CinemachineSwitcher))]
    public class MoveState : State
    {
        [SerializeField] private PointFollowCamera _pointFollowCamera;
        [SerializeField] private ConfigurableJoint _configurableJoint;
        [SerializeField] private AnimatorPlayerController _animatorController;
        [SerializeField] private TrailBrush _trailBrush;
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Animator _animator;

        private Rigidbody _rigidbody;
        private Vector3 _force;
        private Transformable _transformable;
        private CinemachineSwitcher _cinemaSwitcher;

        public bool _isMoveAfterDraw = false;
        public bool _isMove = true;
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
            _animator.enabled = true;

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = false;

            _configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
            _joystick.AxisOptions = AxisOptions.Horizontal;
        }

        private void FixedUpdate()
        {
            if (_isMoveAfterDraw)
            {
                _transformable.MoveToMovingPosition();
                _isMoveAfterDraw = false;
            }
            if (_isMove)
            {
                Move();
            }
        }

        private void Move()
        {
            _force = Vector3.zero;

            TrySetNextPositionX();
            TrySetNextPositionY();
            
            _rigidbody.velocity = _force * _speed;

            _animatorController.Move(_joystick.Direction.x);
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
}
