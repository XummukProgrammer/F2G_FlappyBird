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
        var miniGames = Application.Instance.Managers.GetManager<MiniGames>();
        if (miniGames != null)
        {
            var currentMiniGame = miniGames.CurrentMiniGame;
            if (currentMiniGame != null)
            {
                if (currentMiniGame is FlappyBirdMiniGame)
                {
                    var miniGame = currentMiniGame as FlappyBirdMiniGame;
                    var bird = miniGame.Bird;

                    if (bird)
                    {
                        bird.OnBirdJumped();
                    }
                }
            }
        }
    }
}
