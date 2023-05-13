using UnityEngine;

public class ResourceUseKeyboardPolicy : ResourceUsePolicy
{
    [SerializeField] private KeyCode _keyCode = KeyCode.E;
    [SerializeField] private string _helpHUDName = "HelpText";

    public override bool CanUse()
    {
        if (base.CanUse())
        {
            return Input.GetKeyDown(_keyCode);
        }
        return false;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        var huds = Application.Instance.Managers.GetManager<HUDs>();
        if (huds != null)
        {
            var hud = huds.GetElement(_helpHUDName);
            if (hud && hud is HelpTextHUD)
            {
                (hud as HelpTextHUD).AddOutput($"Enter {_keyCode}", 2);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
