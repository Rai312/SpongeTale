using UnityEngine;
using System;

namespace SpongeTale
{
    public class CelebrationTransition : Transition
    {
        public void OnPaintingReached()
        {
            Debug.Log("OnPaintingReached()");
            NeedTransit = true;
        }
    }
}