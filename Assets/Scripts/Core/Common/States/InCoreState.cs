using UnityEngine;

public class InCoreState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("[Core] onEnter - InCoreState");

        Application.Instance.Location.SetID(LocationID.Core);
        Application.Instance.Level.Play();
    }

    public override void OnExit()
    {
        base.OnExit();

        Debug.Log("[Core] OnExit - InCoreState");
    }
}
