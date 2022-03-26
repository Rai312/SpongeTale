using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Transformable))]
public class CelebrateState : State
{
    private Transformable _transformable;
    private Rigidbody _rigidbody;
    private float _positionZOfEnablingCoroutine = 13.4f;
    private float _durationOfTransitionWaitingDelay = 1f;

    public event UnityAction Celebrated;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transformable = GetComponent<Transformable>();
    }
    private void OnEnable()
    {
        _rigidbody.isKinematic = true;

        _transformable.MoveToCelebratePosition();
        _transformable.MoveToCelebrateRotation();
    }

    private void Update()
    {
        if (transform.position.z < _positionZOfEnablingCoroutine)
        {
            StartCoroutine(WaitTransition());
        }
    }

    private IEnumerator WaitTransition()
    {
        yield return new WaitForSeconds(_durationOfTransitionWaitingDelay);

        Celebrated?.Invoke();
    }
}

