using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Vector2Input
{
    public Vector2 value { get; private set; }

    public Vector2Input(InputAction input)
    {
        m_Input = input;
        value = new Vector2();
    }

    private InputAction m_Input;

    public void Enable()
    {
        m_Input.performed += Update;
        m_Input.canceled += Update;
    }

    public void Disable()
    {
        m_Input.performed -= Update;
        m_Input.canceled -= Update;
    }

    public void Update(InputAction.CallbackContext input)
    {
        value = input.ReadValue<Vector2>();
    }
}
