using UnityEngine;

public class OpenWindowHUD : HUD
{
    [SerializeField] private string _windowID;
    [SerializeField] private LocationID _sceneLocation = LocationID.All;
    [SerializeField] private ActionPriority _priority = ActionPriority.System;

    protected override void OnShow() 
    { 
        base.OnShow();

        var behaviour = GetBehaviour<OpenWindowHUDBehaviour>();
        if (behaviour)
        {
            behaviour.Clicked = OnClicked;
        }
    }

    protected override void OnHide() 
    { 
        base.OnHide();
    }

    private void OnClicked()
    {
        var window = Application.Instance.Managers.GetManager<Windows>().GetElement(_windowID);
        if (window)
        {
            var action = window.GetOpenAction(_sceneLocation, _priority);
            Application.Instance.ActionsQueue.AddAction(action);
        }
    }
}
