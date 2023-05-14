public class FlappyBirdReloadState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        var info = FlappyBirdMiniGameUtils.GetInfo();
        if (info)
        {
            info.ResetLevelData();
        }

        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        if (miniGame)
        {
            miniGame.CreateBird();
            miniGame.RemovePipes();
        }

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "no");
    }
}
