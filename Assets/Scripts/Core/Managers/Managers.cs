using System.Collections.Generic;
using UnityEngine;

public class Managers
{
    private List<BaseManager> _managers = new();

    public void OnInit()
    {
        Debug.Log("[Core] managers init");

        foreach (var manager in _managers)
        {
            manager.OnInit();
        }
    }

    public void OnDeinit()
    {
        foreach (var manager in _managers)
        {
            manager.OnDeinit();
        }
    }

    public void OnUpdate()
    {
        foreach (var manager in _managers)
        {
            manager.OnUpdate();
        }
    }

    public void OnFixedUpdate()
    {
        foreach (var manager in _managers)
        {
            manager.OnFixedUpdate();
        }
    }

    public void AddManager(BaseManager manager)
    {
        _managers.Add(manager);
    }

    public T GetManager<T>() where T : BaseManager
    {
        foreach (var manager in _managers)
        {
            if (manager is T)
            {
                return manager as T;
            }
        }

        return null;
    }
}
