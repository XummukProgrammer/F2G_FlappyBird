using System.Collections.Generic;
using UnityEngine;

public class InventoryWindowBehaviour : WindowBehaviour
{
    [SerializeField] private InventoryWindowResource _resourcePrefab;
    [SerializeField] private Transform _resourcesContainer;

    private List<InventoryWindowResource> _resources = new();

    public void AddResource(Resource resource)
    {
        if (resource.IsVisibleInInventory)
        {
            var res = Instantiate(_resourcePrefab, _resourcesContainer);
            res.Init(resource);
            _resources.Add(res);
        }
    }

    public void Deinit()
    {
        foreach (var resource in _resources)
        {
            resource.Deinit();
        }

        _resources.Clear();
    }
}
