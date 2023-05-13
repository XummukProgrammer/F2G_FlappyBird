using Unity.VisualScripting;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private string _id;

    private Context _localContext = new();

    public string ID => _id;
    public StateGraph StateGraph { get; set; }
    public string NextStateID => GetNextStateID();
    public bool IsInCurrentState => IsInCurrentStateFunc();
    public Context LocalContext => _localContext;

    public virtual void OnEnter()
    {
        var transition = GetComponentInChildren<StateTransitions>();
        if (transition)
        {
            transition.Init(_localContext);
        }
    }

    public virtual void OnExit()
    {
        var transition = GetComponentInChildren<StateTransitions>();
        if (transition)
        {
            transition.Deinit();
        }
    }

    public virtual void OnUpdate()
    {
        var transition = GetComponentInChildren<StateTransitions>();
        if (transition)
        {
            transition.Update();
        }

        if (IsInCurrentState)
        {
            OnPostUpdate();
        }
    }

    public virtual void OnPostUpdate() {}

    private string GetNextStateID()
    {
        var transition = GetComponentInChildren<StateTransitions>();
        if (transition)
        {
            return transition.NextStateID;
        }
        return "";
    }

    private bool IsInCurrentStateFunc()
    {
        if (!StateGraph)
        {
            return false;
        }

        if (StateGraph.CurrentStateID == ID)
        {
            var transition = GetComponentInChildren<StateTransitions>();
            if (transition)
            {
                if (string.IsNullOrEmpty(transition.NextStateID))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
