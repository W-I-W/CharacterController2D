using UnityEngine;

public abstract class CharacterState : MonoBehaviour
{
    protected CharacterStateController characterStateController { get; private set; }
    protected CharacterActions characterActions { get; private set; }
    protected CharacterActor characterActor { get; private set; }


    protected void Start()
    {
        characterStateController = GetComponent<CharacterStateController>();
        characterStateController.AddState(this);
        CharacterBrain brain = transform.parent.GetComponentInChildren<CharacterBrain>();
        characterActor = transform.parent.GetComponent<CharacterActor>();
        characterActions = brain.actions;
    }

    public virtual void OnEnter(CharacterState fromState) { }
    public virtual void OnUpdate(float dt) { }
    public virtual void OnExit() { }
}
