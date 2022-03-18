using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace SpongeTale
{
    public class DrawingTrigger : MonoBehaviour
    {
        [SerializeField] private MoverZ _moverZ;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Brush>(out Brush brush))
            {
                _moverZ.enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Brush>(out Brush brush))
            {
                _moverZ.enabled = true;
            }
        }
    }
}
