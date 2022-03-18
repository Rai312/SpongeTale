using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace SpongeTale
{
    public class Transformable : MonoBehaviour
    {
        public void MoveToDrawingPosition(Vector3 targetPosition, Vector3 targetRotation)
        {
            transform.DOMove(targetPosition, 1.5f);//magic num
            transform.DORotate(targetRotation, 1.5f);//magic num
        }
        
        public void MoveToMovingPosition()
        {
            if (transform.rotation.x != 0)
            {
                transform.DOMove(new Vector3(-0.012f, 1.04f, transform.position.z), 1.0f);//magic num
                transform.DORotate(new Vector3(0, 0, 0), 1.0f);//magic num
            }
        }

        public void MoveToCelebratePosition(Vector3 targetRotation, Vector3 targetPosition)
        {
            transform.DORotate(targetRotation, 2f);//magic int
            transform.DOMove(targetPosition, 2f);//magic int
        }
    }
}
