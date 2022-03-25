using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    [SerializeField] private CelebrateState _celebrateState;
    [SerializeField] private Image _appleImage;
    [SerializeField] private Image _whaleImage;

    private void OnEnable()
    {
        _celebrateState.Celebrated += OnPaintedOver;
    }

    private void OnDisable()
    {
        _celebrateState.Celebrated -= OnPaintedOver;
    }

    private void OnPaintedOver()
    {
        _appleImage.enabled = false;
        _whaleImage.enabled = true;
    }
}

