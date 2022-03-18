using UnityEngine;
using DG.Tweening;
using System;

namespace SpongeTale
{
    [RequireComponent(typeof(Transformable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CinemachineSwitcher))]
    public class DrawState : State
    {
        [SerializeField] private PointFollowCamera _pointFollowCamera;
        [SerializeField] private ConfigurableJoint _configurableJoint;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private TrailBrush _trailBrush;
        [SerializeField] private PaintbrushModel _paintbrushModel;

        private RaycastHit _raycast;
        private Vector3 _force;
        private Vector3 _targetPosition;
        private Rigidbody _rigidbody;
        private CinemachineSwitcher _cinemaSwitcher;

        public bool _isMoving = true;
        public bool _isTest = false;
        private Transformable _transformable;

        private void Awake()
        {
            _transformable = GetComponent<Transformable>();
            _cinemaSwitcher = GetComponent<CinemachineSwitcher>();
        }
        private void OnEnable()
        {
            _cinemaSwitcher.SwitchCamera(_cinemaSwitcher.IsDrawing);
            
            _trailBrush.gameObject.SetActive(false);
            _pointFollowCamera.enabled = false;
            _animator.enabled = false;

            _rigidbody = GetComponent<Rigidbody>();
            
            _configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
            _joystick.AxisOptions = AxisOptions.Both;

            SetDrawPosition();
        }
        
        private void Update()
        {
            if (_isMoving)
            {
                _transformable.MoveToDrawingPosition(_targetPosition, new Vector3(-70.782f, 0, 0));//magic int
                transform.DOMove(_targetPosition, 1.5f);//magic int
                transform.DORotate(new Vector3(-70.782f, 0, 0), 1.5f);//magic int
            }

            if (transform.position.z > 13.93f)//magic int
            {
                _isMoving = false;
                _isTest = true;
            }
            if (_isTest)
            {
                Physics.Raycast(transform.position, -transform.up, out _raycast);

                Move();
            }
        }

        private void SetDrawPosition()
        {
            _targetPosition = new Vector3(Vector3.zero.x, transform.position.y + 0.2f, transform.position.z + 0.18f);//magic int
        }

        private void Move()
        {
            _force = Vector3.zero;

            if (_joystick.Direction.x > 0)
                _force.x = _joystick.Direction.x;
            else if (_joystick.Direction.x < 0)
                _force.x = _joystick.Direction.x;//дубляж

            if (_joystick.Direction.y > 0)
            {
                _force.y = -(_raycast.normal.z * _joystick.Direction.y);
                _force.z = _raycast.normal.y * _joystick.Direction.y;
            }
            else if (_joystick.Direction.y < 0)
            {
                _force.y = _raycast.normal.z * -_joystick.Direction.y;
                _force.z = -(_raycast.normal.y * -_joystick.Direction.y);
            }

            _rigidbody.velocity = _force * _speed;
        }
    }
}
