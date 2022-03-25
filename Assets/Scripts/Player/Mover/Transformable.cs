using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Transformable : MonoBehaviour
{
    private Vector3 _targetDrawingPosition;
    private Vector3 _targetDrawingRotation;
    private float _durationOfTransitionToTargetDrawingPosition = 0.5f;
    private float _durationOfTransitionToTargetDrawingRotation = 0.5f;

    private Vector3 _targetMovingPosition;
    private Quaternion _targetMovingRotation;

    private Vector3 _targetCelebratePosition;
    private Vector3 _targetCelebrateRotation;
    private float _durationOfTransitionToTargetCelebratePosition = 2f;
    private float _durationOfTransitionToTargetCelebrateRotation = 2f;

    private float _targetDrawingPositionY;
    private float _targetDrawingPositionZ;
    private float _targetDrawingRotationX = -70.782f;

    private float _targetMovingPositionX = -0.012f;
    private float _targetMovingPositionY = 1.05f;
    private float _offsetY = 0.2f;
    private float _offsetZ = 0.18f;
    private float _targetMovingRotationW = 1f;

    private float _targetCelebratePositionX = 0.3f;
    private float _targetCelebratePositionY = 0.35f;
    private float _targetCelebratePositionZ = 13.25f;
    private float _targetCelebrateRotationX = -135.58f;
    private float _targetCelebrateRotationY = -16.33f;

    private void Awake()
    {
        _targetDrawingRotation = new Vector3(_targetDrawingRotationX, Vector3.zero.y, Vector3.zero.z);

        _targetMovingPosition = new Vector3(_targetMovingPositionX, _targetMovingPositionY, transform.position.z);
        _targetMovingRotation = new Quaternion(Vector3.zero.x, Vector3.zero.y, Vector3.zero.z, _targetMovingRotationW);

        _targetCelebrateRotation = new Vector3(_targetCelebrateRotationX, _targetCelebrateRotationY, Vector3.zero.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Easel>(out Easel easel))
        {
            _targetMovingPosition = new Vector3(_targetMovingPositionX, _targetMovingPositionY, transform.position.z);

            _targetDrawingPositionY = transform.position.y + _offsetY;
            _targetDrawingPositionZ = transform.position.z + _offsetZ;

            _targetDrawingPosition = new Vector3(Vector3.zero.x, _targetDrawingPositionY, _targetDrawingPositionZ);

            _targetCelebratePositionZ = easel.transform.position.z - 2.25f;
            _targetCelebratePosition = new Vector3(_targetCelebratePositionX, _targetCelebratePositionY, _targetCelebratePositionZ);
        }
    }

    public void MoveToDrawingPosition()
    {
        transform.DOMove(_targetDrawingPosition, _durationOfTransitionToTargetDrawingPosition);
    }

    public void MoveToDrawingRotation()
    {
        transform.DORotate(_targetDrawingRotation, _durationOfTransitionToTargetDrawingRotation);
    }

    public void MoveToMovingPosition()
    {
        transform.position = _targetMovingPosition;
    }

    public void MoveToMovingRotation()
    {
        transform.rotation = _targetMovingRotation;
    }

    public void MoveToCelebratePosition()
    {
        transform.DOMove(_targetCelebratePosition, _durationOfTransitionToTargetCelebratePosition);
    }

    public void MoveToCelebrateRotation()
    {
        transform.DORotate(_targetCelebrateRotation, _durationOfTransitionToTargetCelebrateRotation);
    }
}

