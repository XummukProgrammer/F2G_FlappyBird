using UnityEngine;

public class ResourceHUD : HUD
{
    [SerializeField] private string _resourcesID = "Player";
    [SerializeField] private string _resourceID = "Health";

    private Resource _resource;

    protected override void OnShow()
    {
        base.OnShow();

        var behaviour = GetBehaviour<ResourceHUDBehaviour>();
        if (behaviour)
        {
            _resource = GetResource();
            if (_resource)
            {
                behaviour.SetName(_resource.Name);
                behaviour.SetValue(_resource.Value);

                _resource.ValueChanged += OnResourceValueChanged;
            }
        }
    }

    protected override void OnHide()
    {
        base.OnHide();

        var behaviour = GetBehaviour<ResourceHUDBehaviour>();
        if (behaviour)
        {
            if (_resource)
            {
                _resource.ValueChanged -= OnResourceValueChanged;
            }
        }

        _resource = null;
    }

    private Resource GetResource()
    {
        var resourcesManager = Application.Instance.Managers.GetManager<ResourcesManager>();
        if (resourcesManager != null)
        {
            var resources = resourcesManager.GetElement(_resourcesID);
            if (resources)
            {
                var resource = resources.GetResource(_resourceID);
                if (resource)
                {
                    return resource;
                }
            }
        }
        return null;
    }

    private void OnResourceValueChanged(Resource resource)
    {
        var behaviour = GetBehaviour<ResourceHUDBehaviour>();
        if (behaviour)
        {
            behaviour.SetValue(_resource.Value);
        }
    }
}
