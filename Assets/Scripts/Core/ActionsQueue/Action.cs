using UnityEngine;

public class Action
{
    private bool _isStarted = false;
    private bool _isExecuted = false;

    public string ID { get; set; }
    public LocationID LocationID { get; set; } = LocationID.Core;
    public ActionPriority Priority { get; set; } = ActionPriority.System;

    public virtual bool IsStart() { return true; }
    
    public virtual void OnStart()
    {
        Debug.Log($"[Core] Action {ID} - OnStart");

        _isStarted = true;
    }

    public virtual bool IsStarted() { return _isStarted; }

    public virtual void OnExecute() 
    {
        Debug.Log($"[Core] Action {ID} - OnExecute");

        _isExecuted = true;
    }

    public virtual bool IsExecuted() { return _isExecuted; }

    public virtual bool IsFinish() { return true; }
    
    public virtual void OnFinish() 
    {
        Debug.Log($"[Core] Action {ID} - OnFinish");
    }
}
