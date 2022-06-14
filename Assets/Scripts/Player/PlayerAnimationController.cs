using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private PlayerMovement _pMovement;

    private void Awake()
    {
        _pMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        MovementAnimation();
    }

    private void MovementAnimation()
    {
        _animator.SetBool("IsMove", _pMovement.IsMove);
    }
}