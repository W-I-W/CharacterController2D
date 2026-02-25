using UnityEngine;

public class TestState : CharacterState
{
    public override void OnEnter(CharacterState fromState)
    {
        Debug.Log("Enter");
    }

    public override void OnExit()
    {
        Debug.Log("Exit");

    }
}
