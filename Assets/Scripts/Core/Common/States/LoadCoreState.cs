using UnityEngine;

public class LoadCoreState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("[Core] onEnter - LoadCoreState");

        // TODO: ��������� ��� ������ ���������� �������
        LocalContext.SetVariable("IsCoreLoaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Debug.Log("[Core] OnExit - LoadCoreState");
    }
}
