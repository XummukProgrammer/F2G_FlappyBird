public class HUDs : Manager<HUD>
{
    public void Reload()
    {
        foreach (var hud in _elements)
        {
            hud.Hide();
            hud.ChangeActive();
        }
    }
}
