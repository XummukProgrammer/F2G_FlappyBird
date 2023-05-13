using UnityEngine;

public class InMetaState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("[Core] onEnter - InMetaState");

        Application.Instance.Location.SetID(LocationID.Meta);

        // Debug: Выполняем сразу переход в Core стейт
        LocalContext.SetVariable("IsToCore", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Debug.Log("[Core] OnExit - InMetaState");
    }
}
