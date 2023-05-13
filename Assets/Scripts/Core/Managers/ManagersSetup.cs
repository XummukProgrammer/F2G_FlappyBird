using UnityEngine;

public class ManagersSetup
{
    public void Setup(Managers managers)
    {
        Debug.Log("[Core] managers setup");

        // Add managers
        managers.AddManager(new MiniGames());
        managers.AddManager(new HUDs());
        managers.AddManager(new Windows());
        managers.AddManager(new ResourcesManager());
    }
}
