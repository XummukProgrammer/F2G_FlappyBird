using UnityEngine;

public class ApplicationDebugWindowDelegate
{
    private DebugWindowTabDelegate _delegate;

    public void Init()
    {
        DebugWindow.InitDelegates();

        _delegate = new()
        {
            ModifText = ModifText,
            InstanceCheats = InstanceCheats
        };
        DebugWindow.AddDelegate(DebugWindowTabDelegateID.Basic, _delegate);
    }

    private void ModifText(ref string text)
    {
        text += $"Application name: {Application.Instance.ApplicationName}\n";
        text += $"Application version: {Application.Instance.ApplicationVersion}\n";

        if (Application.Instance.StateGraph)
        {
            text += $"Current game state: {Application.Instance.StateGraph.CurrentStateID}\n";
        }

        text += $"Current location: {Application.Instance.Location.ID}\n";
    }

    private Transform InstanceCheats(Transform container)
    {
        var behaviour = GameObject.Instantiate(Application.Instance.DebugBasicCheatsPanelPrefab, container);
        behaviour.AppClosed = () =>
        {
            UnityEngine.Application.Quit();
        };
        return behaviour.transform;
    }
}
