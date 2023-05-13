using UnityEngine;

public class StateTransitions : MonoBehaviour
{
    public string NextStateID { get; private set; }

    public void Init(Context localContext)
    {
        foreach (var transition in GetComponentsInChildren<StateTransition>())
        {
            transition.Init(localContext);
        }
    }

    public void Deinit()
    {
        NextStateID = "";

        foreach (var transition in GetComponentsInChildren<StateTransition>())
        {
            transition.Deinit();
        }
    }

    public void Update()
    {
        foreach (var transition in GetComponentsInChildren<StateTransition>())
        {
            if (transition.Realized)
            {
                NextStateID = transition.ToStateID;
            }
        }
    }
}
