using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class Paintable : MonoBehaviour
{
    [SerializeField] private P3dPaintDecal _paintDecal;
    [SerializeField] private Color _startColor;
    [SerializeField] private Material _brushMaterial;
    [SerializeField] private TrailBrush _trailBrush;

    private void Start()
    {
        _trailBrush.GetComponent<TrailRenderer>().startColor = _startColor;
        _brushMaterial.color = _startColor;
    }

    public void ChangeColorBrush(Color targetColor)
    {
        _brushMaterial.color = targetColor;
        _paintDecal.Color = targetColor;
    }

    public void ChangeColorTrail(Color targetColor)
    {
        _trailBrush.GetComponent<TrailRenderer>().startColor = targetColor;
    }
}

