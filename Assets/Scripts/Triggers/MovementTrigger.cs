using System.Collections;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;
    [SerializeField] private MoveState _moveState;

    private Coroutine _comeDownSlopeInJob;
    private Coroutine _comeUpSlopeInJob;
    private float _timeElapsed;
    private float _duration = 3.5f;
    private float _offsetY = 0.28f;
    private Vector3 _startPositionMover;

    private void FixedUpdate()
    {
        if (_startPositionMover.y == transform.position.y)
        {
            if (_comeUpSlopeInJob == null)
                return;

            StopCoroutine(_comeUpSlopeInJob);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoverZ>(out MoverZ movingZ))
        {
            _cinemachineSwitcher.SwitchCamera(_cinemachineSwitcher.IsPainting);

            if (movingZ.CheckSpeedScalingAvailability())
            {
                float targetPositionY = movingZ.transform.position.y - _offsetY;
                _comeDownSlopeInJob = StartCoroutine(MoveInPuddle(movingZ, targetPositionY));

                movingZ.ReduceSpeed();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MoverZ>(out MoverZ movingZ))
        {
            _cinemachineSwitcher.SwitchCamera(_cinemachineSwitcher.IsPlaying);

            StopCoroutine(_comeDownSlopeInJob);

            _startPositionMover = movingZ.StartPosition;
            _comeUpSlopeInJob = StartCoroutine(MoveInPuddle(movingZ, _startPositionMover.y));

            movingZ.IncreaseSpeed();

            if (movingZ.CheckSpeedScalingAvailability())
                movingZ.EquateSpeed();
        }
    }

    private IEnumerator MoveInPuddle(MoverZ mover, float positionY)
    {
        while (_timeElapsed < _duration)
        {
            Vector3 targetPosition = new Vector3(mover.transform.position.x, positionY, mover.transform.position.z);
            mover.transform.position = Vector3.Lerp(mover.transform.position, targetPosition, _timeElapsed / _duration);

            _timeElapsed += Time.deltaTime;
            yield return null;
        }
        _timeElapsed = 0;
    }
}
