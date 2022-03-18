using UnityEngine;

namespace SpongeTale
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorPlayerController : MonoBehaviour
    {
        private readonly string _velocity = "Velocity";
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Move(float velocity)
        {
            _animator.SetFloat(_velocity, velocity);
        }
    }
}
