using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isPlayingParticles = false;
    private float _durationOfDelay = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovementTrigger>(out MovementTrigger movementTrigger))
        {
            _particleSystem.startColor = movementTrigger.GetComponent<MeshRenderer>().material.color;
            StartCoroutine(WaitAfterEnter());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MovementTrigger>(out MovementTrigger movementTrigger))
        {
            if (_isPlayingParticles)
            {
                _particleSystem.enableEmission = true;
                _isPlayingParticles = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MovementTrigger>(out MovementTrigger movementTrigger))
        {
            _particleSystem.enableEmission = false;
        }
    }

    private IEnumerator WaitAfterEnter()
    {
        yield return new WaitForSeconds(_durationOfDelay);

        _isPlayingParticles = true;
    }
}

