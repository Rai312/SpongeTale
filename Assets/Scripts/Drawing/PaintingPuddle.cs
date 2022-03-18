using UnityEngine;


namespace SpongeTale
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PaintingPuddle : MonoBehaviour
    {
        private Color _colorPuddle;

        private void Start()
        {
            _colorPuddle = GetComponent<MeshRenderer>().material.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Paintable>(out Paintable paintable))
            {
                paintable.ChangeColorBrush(_colorPuddle);
                paintable.ChangeColorTrail(_colorPuddle);
            }
        }
    }
}
