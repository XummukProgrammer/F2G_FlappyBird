using UnityEngine;

public class FlappyBirdResultWindow : Window
{
    protected override void OnShow()
    {
        base.OnShow();

        var behaviour = GetBehaviour<FlappyBirdResultWindowBehaviour>();
        if (behaviour)
        {
            var info = FlappyBirdMiniGameUtils.GetInfo();
            if (info)
            {
                behaviour.SetMoney(info.AddedMoneyOnLevel);
            }

            behaviour.Resumed = OnResumed;
            behaviour.Mained = OnMained;
        }
    }

    protected override void OnHide()
    {
        base.OnHide();
    }

    private void OnResumed()
    {
        Application.Instance.GlobalContext.SetVariable("IsNewReload", "yes");
    }

    public void OnMained()
    {
        Debug.Log("OnMained");
    }
}
