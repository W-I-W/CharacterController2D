using System;

[System.Serializable]
public class CharacterActions : IDisposable
{
    private InputSystem_Actions m_InputHandler;

    public Vector2Input movement { get; private set; }


    public void Init()
    {
        m_InputHandler = new InputSystem_Actions();

        movement = new Vector2Input(m_InputHandler.Player.Move);

        OnEnable();
    }

    private void OnEnable()
    {
        m_InputHandler.Enable();
        movement.Enable();
    }

    private void OnDisable()
    {
        m_InputHandler.Disable();
        movement.Disable();
    }

    public void Dispose()
    {
        OnDisable();
    }
}
