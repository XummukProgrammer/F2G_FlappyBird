using UnityEngine;

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
}
