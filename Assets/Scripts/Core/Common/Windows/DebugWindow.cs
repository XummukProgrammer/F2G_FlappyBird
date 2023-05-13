using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DebugWindowTabInfo
{
    [SerializeField] private string _name;
    [SerializeField] private DebugWindowTabBehaviour _prefab;

    public string Name => _name;
    public DebugWindowTabBehaviour Prefab => _prefab;
}

public class DebugWindowTabDelegate
{
    public delegate void ModifTextDelegate(ref string text);
    // TODO: Добавить возможность вовзращения нескольких Transform (В случае добавления несольких объектов)
    public delegate Transform InstanceCheatsDelegate(Transform container);

    public ModifTextDelegate ModifText;
    public InstanceCheatsDelegate InstanceCheats;
}

public enum DebugWindowTabDelegateID
{
    Basic,
    MiniGames
}

public class DebugWindow : Window
{
    [SerializeField] private DebugWindowTabInfo[] _tabInfos;
    [SerializeField] private string _baseTabName;

    static private Dictionary<DebugWindowTabDelegateID, List<DebugWindowTabDelegate>> _tabDelegates = new();

    static public void InitDelegates()
    {
        _tabDelegates[DebugWindowTabDelegateID.Basic] = new();
        _tabDelegates[DebugWindowTabDelegateID.MiniGames] = new();
    }

    static public void AddDelegate(DebugWindowTabDelegateID delegateID, DebugWindowTabDelegate tabDelegate)
    {
        _tabDelegates[delegateID].Add(tabDelegate);
    }

    static public void RemoveDelegate(DebugWindowTabDelegateID delegateID, DebugWindowTabDelegate tabDelegate)
    {
        _tabDelegates[delegateID].Remove(tabDelegate);
    }

    static public string GetModifTextWithBasicDelegate(DebugWindowTabDelegateID delegateID)
    {
        string text = "";

        foreach (var tabDelegate in _tabDelegates[delegateID])
        {
            tabDelegate.ModifText?.Invoke(ref text);
        }

        return text;
    }

    static public void InstantiateCheats(DebugWindowTabDelegateID delegateID, Transform container, List<Transform> list)
    {
        foreach (var tabDelegate in _tabDelegates[delegateID])
        {
            if (tabDelegate.InstanceCheats != null)
            {
                var behaviour = tabDelegate.InstanceCheats(container);
                if (behaviour)
                {
                    list.Add(behaviour);
                }
            }
        }
    }

    protected override void OnShow()
    {
        base.OnShow();

        var behaviour = GetBehaviour<DebugWindowBehaviour>();

        foreach (var tabInfo in _tabInfos)
        {
            behaviour.AddTabButton(tabInfo.Name, OnTabClicked);
        }

        ChangeTab(_baseTabName);
    }

    private void ChangeTab(string tabName)
    {
        var behaviour = GetBehaviour<DebugWindowBehaviour>();
        if (!behaviour)
        {
            return;
        }

        var tabBehaviour = GetTabBehaviour(tabName);
        if (!tabBehaviour)
        {
            return;
        }

        behaviour.ChangeTab(tabBehaviour);
    }

    private DebugWindowTabBehaviour GetTabBehaviour(string name)
    {
        foreach (var tabInfo in _tabInfos)
        {
            if (tabInfo.Name == name)
            {
                return tabInfo.Prefab;
            }
        }
        return null;
    }

    private void OnTabClicked(string name)
    {
        ChangeTab(name);
    }
}
