public class FlappyBirdResultState : State
{
    public override void OnEnter()
    {
        base.OnEnter();

        var resultWindow = FlappyBirdMiniGameUtils.GetResultWindow();
        if (resultWindow)
        {
            var action = resultWindow.GetOpenAction();
            Application.Instance.ActionsQueue.AddAction(action);
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        Application.Instance.GlobalContext.SetVariable("IsNewReload", "no");
    }
}
