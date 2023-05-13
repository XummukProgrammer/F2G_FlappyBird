using UnityEngine;

public class Resources : ManagerableElement
{
    [SerializeField] private Resource[] _resources;

    public Resource[] ResourcesData => _resources;

    private void Awake()
    {
        var resourcesManager = Application.Instance.Managers.GetManager<ResourcesManager>();
        if (resourcesManager != null)
        {
            resourcesManager.AddElement(this);
        }
    }

    private void OnDestroy()
    {
        // TODO: Добавить удаление ресурсов
    }

    public override void OnInit()
    {
        foreach (var resource in _resources)
        {
            resource.Init();

            Debug.Log($"[core] Add resource: {Name} - {resource.Name}");
        }
    }

    public Resource GetResource(string name)
    {
        foreach (var resource in _resources)
        {
            if (resource.Name == name)
            {
                return resource;
            }
        }
        return null;
    }

    public void GetDebugInfo(ref string text)
    {
        foreach (var resource in _resources)
        {
            text += $" - Name: {resource.Name}, Value: {resource.Value}\n";
        }
    }
}
