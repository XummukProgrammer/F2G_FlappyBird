using System.Collections.Generic;

public class ActionsQueue
{
    private List<Action> _actions = new();
    private int _finishedActions = 0;
    private int _maxFinishedActions = 3;
    private Action _currentAction;

    public string CurrentActionID => GetCurrentActionID();

    public void OnUpdate()
    {
        if (_actions.Count == 0)
        {
            return;
        }

        var action = _actions[0];

        if (!IsActionInValidLocation(action))
        {
            return;
        }

        if (_finishedActions == _maxFinishedActions && action.Priority != ActionPriority.System)
        {
            return;
        }

        if (action.IsStarted())
        {
            if (!action.IsExecuted())
            {
                action.OnExecute();
            }
            else if (action.IsFinish())
            {
                action.OnFinish();
                _actions.RemoveAt(0);
                _currentAction = null;

                ++_finishedActions;
            }
        }
        else if (action.IsStart())
        {
            action.OnStart();
            _currentAction = action;
        }
    }

    public void AddAction(Action action)
    {
        if (action.Priority == ActionPriority.System)
        {
            _actions.Insert(0, action);
        }
        else
        {
            _actions.Add(action);
        }
    }

    // TODO: Вызывать, если свернуть/развернуть игру, при выходе из брифинга, при входе и выходе из кор стейта.
    public void Reset()
    {
        _finishedActions = 0;
    }

    private bool IsActionInValidLocation(Action action)
    {
        return action.LocationID == LocationID.All || action.LocationID == Application.Instance.Location.ID;
    }

    private string GetCurrentActionID()
    {
        if (_currentAction != null)
        {
            return _currentAction.ID;
        }
        return "";
    }
}
