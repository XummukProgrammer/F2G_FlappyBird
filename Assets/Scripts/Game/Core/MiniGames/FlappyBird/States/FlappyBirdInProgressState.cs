public class FlappyBirdInProgressState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        var liveable = FlappyBirdMiniGameUtils.GetBirdLiveable();
        if (liveable)
        {
            liveable.Died += OnBirdDied;
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        var liveable = FlappyBirdMiniGameUtils.GetBirdLiveable();
        if (liveable)
        {
            liveable.Died -= OnBirdDied;
        }

        Application.Instance.GlobalContext.SetVariable("IsFailed", "no");
    }

    private void OnBirdDied()
    {
        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        var bird = FlappyBirdMiniGameUtils.GetBird();
        if (miniGame && bird)
        {
            miniGame.RemoveBird();

            Application.Instance.GlobalContext.SetVariable("IsFailed", "yes");
        }
    }
}
