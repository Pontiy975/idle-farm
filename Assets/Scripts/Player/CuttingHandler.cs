using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CuttingHandler : MonoBehaviour
{
    internal event Action OnStartCutting;

    [SerializeField]
    private GameObject sickle;

    private bool isCutting = false;

    private AnimationEventHandler _eventHandler;

    private void Awake()
    {
        _eventHandler = GetComponentInChildren<AnimationEventHandler>();
        _eventHandler.OnCuttingFinish += CuttingFinish;
    }

    private void OnDestroy()
    {
        _eventHandler.OnCuttingFinish -= CuttingFinish;
    }

    private void Start()
    {
        sickle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCutting) return;

        if (other.CompareTag("SliceObject"))
        {
            print(true);
            sickle.SetActive(true);
            OnStartCutting?.Invoke();
        }
    }

    private void CuttingFinish()
    {
        sickle.SetActive(false);
        isCutting = false;
    }
}
