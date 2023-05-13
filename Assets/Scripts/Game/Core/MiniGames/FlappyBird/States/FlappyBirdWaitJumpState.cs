public class FlappyBirdWaitJumpState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        if (miniGame)
        {
            var spawner = miniGame.Spawner;
            if (spawner)
            {
                spawner.SetIsEnabled(false);
            }

            var bird = miniGame.Bird;
            if (bird)
            {
                bird.SetIsStop(true);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        if (miniGame)
        {
            var spawner = miniGame.Spawner;
            if (spawner)
            {
                spawner.SetIsEnabled(true);
            }

            var bird = miniGame.Bird;
            if (bird)
            {
                bird.SetIsStop(false);
                bird.OnBirdJumped();
            }
        }

        Application.Instance.GlobalContext.SetVariable("IsWaitJumpTapped", "no");
    }
}
