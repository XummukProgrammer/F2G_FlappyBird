using UnityEngine;

public class HUD : ManagerableElement
{
    [SerializeField] private HUDBehaviour _prefab;
    [SerializeField] private HUDLocation _location;

    private HUDBehaviour _behaviour;

    private void Start()
    {
        Application.Instance.Managers.GetManager<HUDs>().AddElement(this);
        Application.Instance.HUDShowingFlagsController.FlagsChanged += OnHUDShowingFlagsChanged;
    }

    private void OnDestroy()
    {
        // TODO: Удалять элемент из HUDs
    }

    public override void OnInit()
    {
        base.OnInit();

        ChangeActive();
    }

    public void Show()
    {
        if (!_behaviour)
        {
            // TODO: Добавить сортировку элементов в каждом контейнере
            var container = Application.Instance.HUDContainer.GetContainer(_location);
            if (container != null)
            {
                _behaviour = Instantiate(_prefab, container);
                _behaviour.Show();

                OnShow();
            }
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
        }
    }

    private void ChangeActive()
    {
        if (HasHUDInShowingFlags() && IsActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private bool HasHUDInShowingFlags()
    {
        return Application.Instance.HUDShowingFlagsController.HasHudName(Name);
    }

    protected T GetBehaviour<T>() where T : HUDBehaviour
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

    private void OnHUDShowingFlagsChanged(string obj)
    {
        ChangeActive();
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }

    protected virtual bool IsActive() { return true; }
}
