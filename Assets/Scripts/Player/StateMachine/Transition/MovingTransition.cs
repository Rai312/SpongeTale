using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PaintIn3D;
using System;

namespace SpongeTale
{
    public class MovingTransition : Transition
    {
        [SerializeField] private CelebrateState _celebratedState;

        private void OnEnable()
        {
            _celebratedState.Celebrated += OnCelebrated;
        }

        private void OnDisable()
        {
            _celebratedState.Celebrated -= OnCelebrated;
        }

        private void OnCelebrated()
        {
            StartCoroutine(WaitAfterReached());
            NeedTransit = true;
        }

        private IEnumerator WaitAfterReached()
        {
            yield return new WaitForSeconds(1.5f);//magic

            NeedTransit = true;
        }
    }
}
