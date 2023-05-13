using UnityEngine;

public class MiniGameInProgressState : State
{
    public override void OnPostUpdate()
    {
        base.OnPostUpdate();

        var currentMiniGame = Application.Instance.Managers.GetManager<MiniGames>().CurrentMiniGame;
        if (!currentMiniGame)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentMiniGame.Win();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            currentMiniGame.Lose();
        }
    }
}
