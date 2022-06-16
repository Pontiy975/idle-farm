using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerAnimationController : MonoBehaviour
{
    internal event Action OnCuttingFinish;
    
    [SerializeField]
    private Animator _animator;

    private AnimationEventHandler _eventHandler;
    private PlayerMovement _playerMovement;
    private CuttingHandler _cuttingHandler;

    private void Awake()
    {
        _eventHandler = GetComponentInChildren<AnimationEventHandler>();
        _playerMovement = GetComponent<PlayerMovement>();
        _cuttingHandler = GetComponent<CuttingHandler>();

        _cuttingHandler.OnStartCutting += CuttingStart;
    }

    private void OnDestroy()
    {
        _cuttingHandler.OnStartCutting -= CuttingStart;
    }

    private void Update()
    {
        MovementAnimation();

        if (Input.GetMouseButtonDown(0))
        {
                _eventHandler.CuttingFinish();
        }
    }

    private void MovementAnimation()
    {
        _animator.SetBool("IsMove", _playerMovement.IsMove);
    }

    private void CuttingStart()
    {
        _animator.SetTrigger("Cut");
    }
}