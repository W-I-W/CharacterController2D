using System.Net.NetworkInformation;
using UnityEngine;

public class CharacterActor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Body;

    public void Movement(Vector2 value)
    {
        m_Body.MovePosition(m_Body.position + value);
    }
}
