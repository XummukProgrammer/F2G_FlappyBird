using UnityEngine;

public class LoadCoreState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("[Core] onEnter - LoadCoreState");

        // TODO: «агружать как только подт€нутс€ ресурсы
        LocalContext.SetVariable("IsCoreLoaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Debug.Log("[Core] OnExit - LoadCoreState");
    }
}
