using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using CC = UnityEngine.CharacterController;

[RequireComponent(typeof(CC))]
internal class PlayerMovement : MonoBehaviour
{
    //// Events for Stack
    //internal event Action<GameObject> OnRaiseItem;
    //internal event Action OnUnstack;
    //internal event Action OnStopUnstack;

    [SerializeField]
    private Transform body;

    [SerializeField]
    private float speed;

    private bool _isMove;
    internal bool IsMove => _isMove;

    private CC _controller;
    private FloatingJoystick _joystick;

    private void Start()
    {
        _controller = GetComponent<CC>();
        _joystick = FindObjectOfType<FloatingJoystick>();
    }

    private void Update()
    {
        //if (IsPointerOverUIObject()) return;

        Movement();
        Rotation();
    }

    /// <summary>
    /// Movement for the main player (joystick control)
    /// </summary>
    private void Movement()
    {
        Vector3 direction = transform.TransformDirection(new Vector3(_joystick.Horizontal, -9.81f, _joystick.Vertical));
        Vector3 movementVector = speed * Time.deltaTime * direction;

        _controller.Move(movementVector);
        _isMove = _joystick.Horizontal != 0 || _joystick.Vertical != 0;
        print(_isMove);
    }
        
    private void Rotation()
    {
        if (Input.GetMouseButton(0))
        {
            body.rotation = Quaternion.LookRotation(_controller.velocity, Vector3.up);
            body.rotation = Quaternion.Euler(0, body.rotation.eulerAngles.y, 0);
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.CompareTag("StackItem"))
    //    {
    //        Destroy(hit.gameObject.GetComponent<Collider>());
    //        OnRaiseItem?.Invoke(hit.gameObject);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("UnstackTrigger")) OnUnstack?.Invoke();
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("UnstackTrigger")) OnStopUnstack?.Invoke();
    //}

    //private bool IsPointerOverUIObject()
    //{
    //    PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    //    eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

    //    for (int i = 0; i < results.Count; i++)
    //        if (results[i].gameObject.layer == 10) return true;

    //    return false;
    //}
}
