using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    [SerializeField] private CharacterState m_InitialState;

    private CharacterState m_CurrentState;
    private Dictionary<Type, CharacterState> m_States = new Dictionary<Type, CharacterState>();

    private float m_DeltaTime;


    private void Start()
    {
        transform.parent.GetComponent<CharacterActor>();
        m_CurrentState = m_InitialState;
        m_CurrentState.OnEnter(m_InitialState);
    }

    private void FixedUpdate()
    {
        m_DeltaTime = Time.deltaTime;//не Fixed!

        m_CurrentState.OnUpdate(m_DeltaTime);
    }


    public void SetState<T>() where T : CharacterState
    {
        Type type = typeof(T);
        if (!m_States.TryGetValue(type, out CharacterState state)) return;
        CharacterState fromState = m_CurrentState;
        m_CurrentState.OnExit();
        m_CurrentState = state;
        m_CurrentState.OnEnter(fromState);
    }

    public void AddState<T>(T state) where T : CharacterState
    {
        m_States.Add(state.GetType(), state);
    }
}
