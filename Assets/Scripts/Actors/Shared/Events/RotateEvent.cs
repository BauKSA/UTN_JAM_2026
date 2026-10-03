using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum RotateDirection
{
    Right,
    Left
}

public class RotateEvent : InputEvent
{
    private readonly RotateDirection _direction;
    private readonly RotationStateController _rotationState;

    public RotateEvent(RotateDirection direction, RotationStateController rotationState)
    {
        _direction = direction;
        _rotationState = rotationState;
    }
    public override void Execute(InputAction.CallbackContext context)
    {
        if (!_rotationState.Active || !_rotationState.CanRotate)
            return;

        if(_direction == RotateDirection.Right)
        {
            _rotationState.Rotation.Right = true;
        }
        else if(_direction == RotateDirection.Left)
        {
            _rotationState.Rotation.Left = true;
        }
    }

    public override void Stop(InputAction.CallbackContext context)
    {
        if (_direction == RotateDirection.Right)
        {
            _rotationState.Rotation.Right = false;
        }
        else if (_direction == RotateDirection.Left)
        {
            _rotationState.Rotation.Left = false;
        }
    }
}