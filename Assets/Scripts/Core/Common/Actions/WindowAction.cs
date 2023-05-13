public class WindowAction : Action
{
    public delegate void DefaultDelegate();

    public DefaultDelegate Showed;
    public DefaultDelegate Hidden;

    private Window _window;
    private bool _isWindowShowed = false;
    private bool _isWindowHidden = false;

    public string WindowID { get; set; }

    public override void OnExecute()
    {
        base.OnExecute();

        _window = Application.Instance.Managers.GetManager<Windows>().GetElement(WindowID);
        _window.Showed += OnWindowShowed;
        _window.Hidden += OnWindowHidden;
        _window.Show();
    }

    private void OnWindowShowed()
    {
        _isWindowShowed = true;

        Showed?.Invoke();
    }

    public override bool IsFinish() 
    { 
        return _isWindowShowed && _isWindowHidden; 
    }

    public override void OnFinish()
    {
        _window.Showed -= OnWindowShowed;
        _window.Hidden -= OnWindowHidden;
    }

    private void OnWindowHidden()
    {
        _isWindowHidden = true;

        Hidden?.Invoke();
    }
}
