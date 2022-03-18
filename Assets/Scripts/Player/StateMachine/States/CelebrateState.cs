using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace SpongeTale
{
    [RequireComponent(typeof(Transformable))]
    public class CelebrateState : State
    {
        private Transformable _transformable;
        private Rigidbody _rigidbody;
        private Vector3 _targetPosition;
        private Vector3 _targetRotation;

        public bool _isMoving = false;
        public event UnityAction Celebrated;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transformable = GetComponent<Transformable>();
        }
        private void OnEnable()
        {
            _rigidbody.isKinematic = true;
            SetPositionAfterDraw();
            SetRotationAfterDraw();
        }

        private void Update()
        {
            if (_isMoving)
            {
                _transformable.MoveToCelebratePosition(_targetRotation, _targetPosition);
                _isMoving = false;
            }

            if (transform.position.z < 13.4f)
            {
                StartCoroutine(WaitTransition());
            }
        }

        private IEnumerator WaitTransition()
        {
            yield return new WaitForSeconds(1f);//magic int

            Celebrated?.Invoke();
        }

        private void SetPositionAfterDraw()
        {
            Debug.Log("SetPositionAfterDraw");
            _targetPosition = new Vector3(0.30f, 0.35f, 13.25f);//magic int
        }

        private void SetRotationAfterDraw()
        {
            Debug.Log("SetRotationAfterDraw");
            _targetRotation = new Vector3(-135.58f, -16.33f, 0);//magic int
        }
    }
}
