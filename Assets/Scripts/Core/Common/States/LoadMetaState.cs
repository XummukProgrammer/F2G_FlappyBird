using UnityEngine;

public class LoadMetaState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("[Core] onEnter - LoadMetaState");

        // TODO: ��������� ��� ������ ���������� �������
        LocalContext.SetVariable("IsMetaLoaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Debug.Log("[Core] OnExit - LoadMetaState");
    }
}
