public class FlappyBirdReloadState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        // TODO: ������� ������ Reload � ������ ��� ���� ������� ������ �����������?

        var miniGame = FlappyBirdMiniGameUtils.GetMiniGame();
        if (miniGame)
        {
            // TODO: � ������� �������� ��������� ������?
            miniGame.CreateBird();
        }

        var spawner = FlappyBirdMiniGameUtils.GetSpawner();
        if (spawner)
        {
            spawner.Reload();
        }

        var info = FlappyBirdMiniGameUtils.GetInfo();
        if (info)
        {
            info.Reload();
        }

        var archive = FlappyBirdMiniGameUtils.GetArchive();
        if (archive)
        {
            archive.Reload();
        }

        var huds = Application.Instance.Managers.GetManager<HUDs>();
        if (huds != null)
        {
            huds.Reload();
        }

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "yes");
    }

    public override void OnExit()
    {
        base.OnExit();

        Application.Instance.GlobalContext.SetVariable("IsReloaded", "no");
    }
}
