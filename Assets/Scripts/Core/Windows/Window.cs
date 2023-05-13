using UnityEngine;

public class Window : ManagerableElement
{
    public event System.Action Showed;
    public event System.Action Hidden;
    public event System.Action Closed;

    [SerializeField] private WindowBehaviour _prefab;
    [SerializeField] private string _hudShowingFlags = "Empty";

    private WindowBehaviour _behaviour;

    private void Start()
    {
        Application.Instance.Managers.GetManager<Windows>().AddElement(this);
    }

    private void OnDestroy()
    {
        // TODO: Удалять элемент из Windows
    }

    public void Show()
    {
        if (!_behaviour)
        {
            _behaviour = Instantiate(_prefab, Application.Instance.WindowContainer.transform);
            _behaviour.Show();
            _behaviour.Closed = OnClose;

            Application.Instance.HUDShowingFlagsController.SetFlags(_hudShowingFlags);

            OnShow();
        }
    }

    public void Hide()
    {
        if (_behaviour)
        {
            OnHide();

            _behaviour.Hide();
            Destroy(_behaviour.gameObject);
            _behaviour = null;

            Application.Instance.HUDShowingFlagsController.PopFlags();
        }
    }

    public Action GetOpenAction(LocationID locationID = LocationID.All, ActionPriority priority = ActionPriority.System, 
        WindowAction.DefaultDelegate onShowed = null, WindowAction.DefaultDelegate onHidden = null)
    {
        var action = new WindowAction();
        action.ID = $"OpenWindow_{Name}_Action";
        action.LocationID = locationID;
        action.Priority = priority;
        action.Showed = onShowed;
        action.Hidden = onHidden;
        action.WindowID = Name;
        return action;
    }

    private void OnClose()
    {
        Closed?.Invoke();
        Hide();
    }

    protected virtual void OnShow() 
    {
        Showed?.Invoke();
    }

    protected virtual void OnHide() 
    {
        Hidden?.Invoke();
    }

    protected T GetBehaviour<T>() where T : WindowBehaviour
    {
        if (_behaviour)
        {
            if (_behaviour.gameObject.TryGetComponent(out T targetBehaviour))
            {
                return targetBehaviour;
            }
        }
        return null;
    }
}
