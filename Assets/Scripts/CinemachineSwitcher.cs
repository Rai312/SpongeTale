using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCameraPlaying;
    [SerializeField] private CinemachineVirtualCamera _virtualCameraPainting;
    [SerializeField] private CinemachineVirtualCamera _virtualCameraDrawing;

    private int _lowPriorityValue = 0;
    private int _highPriorityValue = 2;

    public event UnityAction ChangedPositionCamera;

    public readonly string IsPlaying = "IsPlaying";
    public readonly string IsPainting = "IsPainting";
    public readonly string IsDrawing = "IsDrawing";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DrawingTrigger>(out DrawingTrigger drawingTrigger))
        {
            ChangedPositionCamera?.Invoke();
        }
    }

    public void SwitchCamera(string state)
    {
        if (state == IsPlaying)
        {
            _virtualCameraPlaying.Priority = _highPriorityValue;
            _virtualCameraPainting.Priority = _lowPriorityValue;
            _virtualCameraDrawing.Priority = _lowPriorityValue;
        }
        else if (state == IsPainting)
        {
            _virtualCameraPlaying.Priority = _lowPriorityValue;
            _virtualCameraPainting.Priority = _highPriorityValue;
            _virtualCameraDrawing.Priority = _lowPriorityValue;
        }
        else if (state == IsDrawing)
        {
            _virtualCameraPlaying.Priority = _lowPriorityValue;
            _virtualCameraPainting.Priority = _lowPriorityValue;
            _virtualCameraDrawing.Priority = _highPriorityValue;
        }
    }
}

