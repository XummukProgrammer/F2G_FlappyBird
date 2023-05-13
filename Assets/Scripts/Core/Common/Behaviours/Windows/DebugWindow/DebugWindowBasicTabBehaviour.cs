using System.Collections.Generic;
using UnityEngine;

public class DebugWindowBasicTabBehaviour : DebugWindowTabBehaviour
{
    [SerializeField] private UpdatableText _text;

    [SerializeField] private Transform _cheatsContainer;

    private List<Transform> _cheatsBehaviours = new();

    private void Start()
    {
        DebugWindow.InstantiateCheats(DebugWindowTabDelegateID.Basic, _cheatsContainer, _cheatsBehaviours);
    }

    private void Update()
    {
        _text.SetText(DebugWindow.GetModifTextWithBasicDelegate(DebugWindowTabDelegateID.Basic));
    }
}
