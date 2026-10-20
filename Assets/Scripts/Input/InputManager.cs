using UnityEngine;

public class InputManager
{
    private InputSystem inputSystem;
    
    public Vector2 InputDirection => inputSystem.Player.Move.ReadValue<Vector2>();
    /*! Same As:
     public Vector2 GetInputDirection()
    {
        return inputSystem.Player.Move.ReadValue<Vector2>();
    }
    */

    public InputManager()
    {
        inputSystem = new InputSystem();
        inputSystem.Enable();
    }
    
    public void DisableInput()
    {
        inputSystem.Disable();
    }
}
