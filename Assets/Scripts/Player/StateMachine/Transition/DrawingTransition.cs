using UnityEngine;
using UnityEngine.Events;

public class DrawingTransition : Transition
{
    public event UnityAction Switched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DrawingTrigger>(out DrawingTrigger drawingTrigger))
        {
            Switched?.Invoke();
            NeedTransit = true;
        }
    }
}

