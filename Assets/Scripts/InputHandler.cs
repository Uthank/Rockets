using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float _clampTouchRadiusFromWidth = 1;
    
    private PlayerInput _input;
    private bool _isTouched;
    private float _halfScreenWidth;
    private float _clampRadius;
    
    public Vector2 PointOnScreen { get; private set; }
    
    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Touch.started += ctx => StartMove();
        _input.Player.Touch.canceled += ctx => EndMove();
        _input.Enable();
        _halfScreenWidth = Screen.width / 2f;
        _clampRadius = _halfScreenWidth * _clampTouchRadiusFromWidth;
    }

    private void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        if (_isTouched == true)
        {
            Vector2 touchPosition;
            touchPosition.x = Mouse.current.position.ReadValue().x - _halfScreenWidth;
            touchPosition.y = Mouse.current.position.ReadValue().y - _halfScreenWidth;

            if (touchPosition.magnitude > _clampRadius)
                touchPosition = touchPosition.normalized * _clampRadius;

            PointOnScreen = touchPosition / _clampRadius;
        }
    }

    private void StartMove()
    {
        _isTouched = true;
    }

    private void EndMove()
    {
        _isTouched= false;
    }
}
