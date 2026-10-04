using UnityEngine;

public class TestState : MonoBehaviour
{
    StateController state;
    void Awake()
    {
        state = GetComponent<StateController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            state.attacking = true;
            state.idle = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            state.attacking = false;
            state.idle = true;
        }
    }
}
