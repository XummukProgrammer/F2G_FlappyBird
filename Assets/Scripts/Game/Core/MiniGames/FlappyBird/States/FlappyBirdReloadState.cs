public class FlappyBirdReloadState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "no");
    }
}
