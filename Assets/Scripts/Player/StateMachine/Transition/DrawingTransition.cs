using UnityEngine;

namespace SpongeTale
{
    public class DrawingTransition : Transition
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DrawingTrigger>(out DrawingTrigger drawingTrigger))
            {
                NeedTransit = true;
            }
        }
    }
}
