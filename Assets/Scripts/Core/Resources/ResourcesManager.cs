public class ResourcesManager : Manager<Resources>
{
    public void GetDebugInfo(ref string text)
    {
        foreach (var element in _elements)
        {
            text += "----\n";
            text += $" {element.Name}:\n";
            element.GetDebugInfo(ref text);
            text += "----\n";
        }
    }
}
