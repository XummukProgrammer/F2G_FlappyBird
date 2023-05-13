using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : Window
{
    [SerializeField] private string _resourcesName;

    protected override void OnShow()
    {
        base.OnShow();

        var behaviour = GetBehaviour<InventoryWindowBehaviour>();
        if (behaviour)
        {
            var resourcesManager = Application.Instance.Managers.GetManager<ResourcesManager>();
            if (resourcesManager != null)
            {
                var resources = resourcesManager.GetElement(_resourcesName);
                if (resources != null)
                {
                    foreach (var resource in resources.ResourcesData)
                    {
                        behaviour.AddResource(resource);
                    }
                }
            }
        }
    }

    protected override void OnHide()
    {
        base.OnHide();

        var behaviour = GetBehaviour<InventoryWindowBehaviour>();
        if (behaviour)
        {
            behaviour.Deinit();
        }
    }
}
