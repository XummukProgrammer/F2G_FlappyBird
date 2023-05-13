using System.Collections.Generic;
using UnityEngine;

public class DebugWindowBehaviour : WindowBehaviour
{
    [SerializeField] private Transform _tabsButtonsContainer;
    [SerializeField] private DebugWindowTabButtonBehaviour _tabButtonPrefab;
    [SerializeField] private Transform _tabContainer;

    private List<DebugWindowTabButtonBehaviour> _tabsButtonsBehaviours = new();
    private DebugWindowTabBehaviour _tabBehaviour;

    public void AddTabButton(string name, DebugWindowTabButtonBehaviour.ClickedDelegate onClicked)
    {
        var newTabButton = Instantiate(_tabButtonPrefab, _tabsButtonsContainer);
        newTabButton.SetName(name);
        newTabButton.Clicked = onClicked;
        _tabsButtonsBehaviours.Add(newTabButton);
    }

    public void ChangeTab(DebugWindowTabBehaviour tabPrefab)
    {
        if (_tabBehaviour != null)
        {
            Destroy(_tabBehaviour.gameObject);
            _tabBehaviour = null;
        }

        _tabBehaviour = Instantiate(tabPrefab, _tabContainer);
    }
}
