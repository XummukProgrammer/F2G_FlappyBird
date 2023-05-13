public class MiniGameWinCondition : Condition
{
    public override bool IsResult()
    {
        var currentMiniGame = Application.Instance.Managers.GetManager<MiniGames>().CurrentMiniGame;
        if (currentMiniGame)
        {
            return currentMiniGame.IsWin;
        }
        return false;
    }
}
