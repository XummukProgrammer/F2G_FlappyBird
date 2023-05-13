using UnityEngine;

public class MiniGame : ManagerableElement
{
    private StateGraph _stateGraph;
    private bool _isDisable = true;
    private bool _isWin = false;
    private bool _isLose = false;
    private DebugWindowTabDelegate _debugWindowDelegate;

    public StateGraph StateGraph => _stateGraph;
    public Camera Camera { get; set; }
    public bool IsDisable => _isDisable;
    public bool IsWin => _isWin;
    public bool IsLose => _isLose;

    public override void OnInit() 
    { 
        base.OnInit();

        _stateGraph = GetComponentInChildren<StateGraph>();

        if (_stateGraph)
        {
            _stateGraph.OnInit();
        }

        _debugWindowDelegate = new DebugWindowTabDelegate
        {
            ModifText = DebugModifText,
            InstanceCheats = DebugInstanceCheats
        };
        DebugWindow.AddDelegate(DebugWindowTabDelegateID.MiniGames, _debugWindowDelegate);
    }

    public override void OnDeinit() 
    { 
        base.OnDeinit();

        if (_stateGraph)
        {
            _stateGraph.OnDeinit();
        }

        DebugWindow.RemoveDelegate(DebugWindowTabDelegateID.MiniGames, _debugWindowDelegate);
    }

    public override void OnUpdate() 
    { 
        base.OnUpdate();

        if (_stateGraph)
        {
            _stateGraph.OnUpdate();
        }
    }

    public override void OnFixedUpdate() 
    { 
        base.OnUpdate();
    }

    public virtual void StartMiniGame()
    {
        Debug.Log($"[Core] StartMiniGame - {Name}");

        OnInit();

        _isDisable = false;
    }

    public virtual void ResetMiniGame()
    {
        _isDisable = true;
        _isWin = false;
        _isLose = false;
    }

    public void Win()
    {
        _isWin = true;
    }

    public void Lose()
    {
        _isLose = true;
    }

    protected virtual void DebugModifText(ref string text)
    {
        text += $"Current minigame name: {Name}\n";

        var stateGraph = StateGraph;
        if (stateGraph)
        {
            text += $"Current minigame state: {stateGraph.CurrentStateID}\n";
        }

        var resourcesManager = Application.Instance.Managers.GetManager<ResourcesManager>();
        if (resourcesManager != null)
        {
            text += "Resources:\n";
            resourcesManager.GetDebugInfo(ref text);
        }
    }

    protected virtual Transform DebugInstanceCheats(Transform container)
    {
        return null;
    }
}
