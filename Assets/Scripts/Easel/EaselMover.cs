using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpongeTale
{
    public class EaselMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _offsetX = 3f;
        private float _offsetY = 0.2f;
        private Vector3 _targetPosition;
        private bool _isMoving = false;

        private void Start()
        {
            _targetPosition = new Vector3(transform.position.x + _offsetX, transform.position.y + _offsetY, transform.position.z);
        }

        private void FixedUpdate()
        {
            TryMove();
        }

        public void OnPaintingReached()
        {
            StartCoroutine(WaitAfterCelebration());
            TryMove();
        }

        private void TryMove()
        {
            if (_isMoving)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }

        private IEnumerator WaitAfterCelebration()
        {
            yield return new WaitForSeconds(2f);//magic int

            _isMoving = true;
        }

    }
}