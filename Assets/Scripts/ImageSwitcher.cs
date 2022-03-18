using UnityEngine;
using UnityEngine.UI;

namespace SpongeTale
{
    public class ImageSwitcher : MonoBehaviour
    {
        //[SerializeField] Player _player;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _sprite;

        private void OnEnable()
        {
            //_player.PaintedOver += OnPaintedOver;
        }

        private void OnDisable()
        {
            //_player.PaintedOver -= OnPaintedOver;
        }

        private void OnPaintedOver()
        {
            _image.sprite = _sprite;
        }
    }
}
