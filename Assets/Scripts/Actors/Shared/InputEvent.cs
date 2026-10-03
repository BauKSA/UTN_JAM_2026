using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputEvent
{
    public abstract void Execute(InputAction.CallbackContext context);
    public virtual void Stop(InputAction.CallbackContext context) { }
}