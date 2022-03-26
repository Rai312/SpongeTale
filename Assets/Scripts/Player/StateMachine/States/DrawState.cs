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
        [SerializeField] private ConfigurableJoint _configurableJointChild;
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private TrailBrush _trailBrush;
        [SerializeField] private PaintbrushModel _paintbrushModel;

        private RaycastHit _raycast;
        private Vector3 _force;
        private Rigidbody _rigidbody;
        private CinemachineSwitcher _cinemaSwitcher;
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

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;

            _transformable.MoveToDrawingRotation();
            _transformable.MoveToDrawingPosition();

            _joystick.AxisOptions = AxisOptions.Both;
        }

        private void FixedUpdate()
        {
            Physics.Raycast(transform.position, -transform.up, out _raycast);

            Draw();

        }

        private void Draw()
        {
            float horizontal = _joystick.Direction.x;
            float vertical = _joystick.Direction.y;

            Vector3 normal = _raycast.normal;

            Vector3 direction = new Vector3(horizontal, 0, vertical);

            Vector3 directionAlongSurface = (direction - Vector3.Dot(direction, normal) * normal).normalized;
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}
