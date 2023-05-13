public class BirdJumpHUD : HUD
{
    protected override void OnShow()
    {
        base.OnShow();

        var behaviour = GetBehaviour<BirdJumpHUDBehaviour>();
        if (behaviour)
        {
            behaviour.TappedToArea += OnTappedToArea;
        }
    }

    protected override void OnHide()
    {
        base.OnHide();

        var behaviour = GetBehaviour<BirdJumpHUDBehaviour>();
        if (behaviour)
        {
            behaviour.TappedToArea -= OnTappedToArea;
        }
    }

    private void OnTappedToArea()
    {
        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        if (miniGame)
        {
            var bird = miniGame.Bird;

            if (bird)
            {
                if (bird.IsStopped)
                {
                    Application.Instance.GlobalContext.SetVariable("IsWaitJumpTapped", "yes");
                }
                else
                {
                    bird.OnBirdJumped();
                }
            }
        }
    }
}
