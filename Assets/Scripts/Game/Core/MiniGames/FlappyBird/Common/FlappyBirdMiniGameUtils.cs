public static class FlappyBirdMiniGameUtils
{
    public static FlappyBirdMiniGame GetMiniGame()
    {
        var miniGames = Application.Instance.Managers.GetManager<MiniGames>();
        if (miniGames != null)
        {
            var currentMiniGame = miniGames.CurrentMiniGame;
            if (currentMiniGame != null)
            {
                if (currentMiniGame is FlappyBirdMiniGame)
                {
                    return currentMiniGame as FlappyBirdMiniGame;
                }
            }
        }
        return null;
    }

    public static Bird GetBird()
    {
        var miniGame = GetMiniGame();
        if (miniGame)
        {
            return miniGame.Bird;
        }
        return null;
    }

    public static CharacterLiveable GetBirdLiveable()
    {
        var bird = GetBird();
        if (bird)
        {
            var character = bird.Character;
            if (character)
            {
                return character.Liveable;
            }
        }
        return null;
    }

    public static FlappyBirdResultWindow GetResultWindow()
    {
        var miniGame = GetMiniGame();
        if (miniGame)
        {
            return miniGame.ResultWindow;
        }
        return null;
    }

    public static FlappyBirdArchive GetArchive()
    {
        var miniGame = GetMiniGame();
        if (miniGame)
        {
            return miniGame.Archive;
        }
        return null;
    }

    public static FlappyBirdInfo GetInfo()
    {
        var miniGame = GetMiniGame();
        if (miniGame)
        {
            return miniGame.Info;
        }
        return null;
    }

    public static Spawner GetSpawner()
    {
        var miniGame = GetMiniGame();
        if (miniGame)
        {
            return miniGame.Spawner;
        }
        return null;
    }
}
