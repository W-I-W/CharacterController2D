using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int m_FPS = 60;


    private void Start()
    {
        Application.targetFrameRate = m_FPS;
    }
}
