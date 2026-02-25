using UnityEngine;

public class NormalMovement : CharacterState
{
    [SerializeField] private MovementParameters m_Movement;

    private float m_CurrentSpeed = 0f;

    public override void OnUpdate(float dt)
    {
        float speed = (characterActions.movement.value.x * m_Movement.speedMovement * dt);
        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, speed, dt);
        characterActor.Movement(new Vector2(m_CurrentSpeed, 0));
    }
}

[System.Serializable]
public class MovementParameters
{
    [SerializeField] private float m_SpeedMovement = 2;

    public float speedMovement => m_SpeedMovement;
}


