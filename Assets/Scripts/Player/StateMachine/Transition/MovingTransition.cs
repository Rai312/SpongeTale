using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PaintIn3D;
using System;

public class MovingTransition : Transition
{
    [SerializeField] private CelebrateState _celebratedState;

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
        NeedTransit = true;
        Switched.Invoke();
    }
}

