using UnityEngine;

public class Resource : MonoBehaviour
{
    public event System.Action<int, int> ValueAdded;
    public event System.Action<int, int> ValueTaked;
    public event System.Action<Resource> ValueChanged;

    [SerializeField] private string _name;
    [SerializeField] private ResourceChangePolicy _changePolicy;
    [SerializeField] private int _startValue = 0;
    [SerializeField] private bool _isVisibleInInventory = true;

    private int _value;

    public string Name => _name;
    public int Value => _value;
    public bool IsVisibleInInventory => _isVisibleInInventory;

    public void Init()
    {
        _value = _startValue;
    }

    public void AddValue(int addValue, bool isNoSignals = false)
    {
        if (_changePolicy)
        {
            int prevValue = _value;
            _value = _changePolicy.AddValue(_value, addValue);

            if (prevValue != _value && !isNoSignals)
            {
                ValueAdded?.Invoke(prevValue, _value);
                ValueChanged?.Invoke(this);
            }
        }
    }

    public void TakeValue(int takeValue, bool isNoSignals = false)
    {
        if (_changePolicy)
        {
            int prevValue = _value;
            _value = _changePolicy.TakeValue(_value, takeValue);

            if (prevValue != _value && !isNoSignals)
            {
                ValueTaked?.Invoke(prevValue, _value);
                ValueChanged?.Invoke(this);
            }
        }
    }
}
