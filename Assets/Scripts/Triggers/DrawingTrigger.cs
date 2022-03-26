using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DrawingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoverZ>(out MoverZ moverZ))
        {
            moverZ.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MoverZ>(out MoverZ moverZ))
        {
            moverZ.enabled = true;
        }
    }
}

