using UnityEngine;

[DefaultExecutionOrder(-100)]
public class CharacterBrain : MonoBehaviour
{
    public CharacterActions actions { get; private set; }


    public void Awake()
    {
        actions = new CharacterActions();
        actions.Init();
    }

    private void OnDestroy()
    {
        actions.Dispose();
    }
}
