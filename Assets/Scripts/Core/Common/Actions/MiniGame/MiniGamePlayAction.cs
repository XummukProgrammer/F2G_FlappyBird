public class MiniGamePlayAction : Action
{
    public string MiniGameName { get; set; }

    public override void OnExecute()
    {
        base.OnExecute();

        Application.Instance.Managers.GetManager<MiniGames>().PlayMiniGame(MiniGameName);
    }
}
