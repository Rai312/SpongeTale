using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailBrush : MonoBehaviour
{
    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public void DisableTrail()
    {
        _trailRenderer.enabled = false;
    }

    public void EnableTrail()
    {
        _trailRenderer.enabled = true;
    }
}

