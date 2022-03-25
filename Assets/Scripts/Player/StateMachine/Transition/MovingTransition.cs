using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PaintIn3D;
using System;

public class MovingTransition : Transition
{
    [SerializeField] private CelebrateState _celebratedState;

    //private float _durationOfDelay = 1.5f;

    public event UnityAction Switched;

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
        //StartCoroutine(WaitAfterReached());
        NeedTransit = true;
        Switched.Invoke();
    }

    //private IEnumerator WaitAfterReached()
    //{
    //    yield return new WaitForSeconds(_durationOfDelay);

    //    NeedTransit = true;
    //}
}

