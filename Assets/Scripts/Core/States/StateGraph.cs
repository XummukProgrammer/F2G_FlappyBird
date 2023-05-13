using UnityEngine;

public class StateGraph : MonoBehaviour
{
    [SerializeField] private string _startStateID;

    private State _currentState;

    public string CurrentStateID => GetCurrentStateID();

    public void OnInit()
    {
        foreach (var state in GetComponentsInChildren<State>())
        {
            state.StateGraph = this;
        }

        ChangeState(_startStateID);
    }

    public void OnDeinit()
    {
        _currentState = null;
    }

    public void OnUpdate()
    {
        if (_currentState)
        {
            if (_currentState.NextStateID != "")
            {
                ChangeState(_currentState.NextStateID);
            }

            _currentState.OnUpdate();
        }
    }

    public State GetState(string ID)
    {
        foreach (var state in GetComponentsInChildren<State>())
        {
            if (state.ID == ID)
            {
                return state;
            }
        }
        return null;
    }

    private string GetCurrentStateID()
    {
        if (_currentState)
        {
            return _currentState.ID;
        }
        return "";
    }

    private void ChangeState(string ID)
    {
        State newState = GetState(ID);

        if (newState)
        {
            if (_currentState)
            {
                _currentState.OnExit();
            }

            _currentState = newState;
            _currentState.OnEnter();
        }
    }
}
