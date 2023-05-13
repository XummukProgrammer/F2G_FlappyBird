using UnityEngine;

[System.Serializable]
public class HUDShowingFlags
{
    [SerializeField] private string _ID;
    [SerializeField] private string[] _hudNames;

    public string ID => _ID;

    public bool HasHudName(string name)
    {
        foreach (var hudName in _hudNames)
        {
            if (hudName == name)
            {
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public class HUDShowingFlagsController
{
    public event System.Action<string> FlagsChanged;

    [SerializeField] private HUDShowingFlags[] _flags;
    [SerializeField] private string _defaultID;

    private string _prevFlags;
    private string _currentFlags;

    public void Init()
    {
        SetFlags(_defaultID);
    }

    public void SetFlags(string id)
    {
        _prevFlags = _currentFlags;
        _currentFlags = id;
        OnFlagsChanged();
    }

    public void PopFlags()
    {
        _currentFlags = _prevFlags;
        OnFlagsChanged();
    }

    public bool HasHudName(string name)
    {
        var flags = GetFlags(_currentFlags);
        if (flags != null)
        {
            return flags.HasHudName(name);
        }
        return false;
    }

    private HUDShowingFlags GetFlags(string id)
    {
        foreach (var flags in _flags)
        {
            if (flags.ID == id)
            {
                return flags;
            }
        }
        return null;
    }

    private void OnFlagsChanged()
    {
        FlagsChanged?.Invoke(_currentFlags);
    }
}
