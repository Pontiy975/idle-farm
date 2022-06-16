using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AnimationEventHandler : MonoBehaviour
{
    internal event Action OnCuttingFinish;

    public void CuttingFinish()
    {
        print(false);
        OnCuttingFinish?.Invoke();
    }
}
