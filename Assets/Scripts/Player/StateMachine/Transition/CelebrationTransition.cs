using UnityEngine;
using System;

public class CelebrationTransition : Transition
{
    public void OnPaintingReached()
    {
        NeedTransit = true;
    }
}
