using UnityEngine;

public class LimitedResourceChangePolicy : ResourceChangePolicy
{
    [SerializeField] private int _minValue = 0;
    [SerializeField] private int _maxValue = 99999;

    public override int AddValue(int currentValue, int addValue)
    {
        return GetClampableValue(currentValue + addValue);
    }

    public override int TakeValue(int currentValue, int takeValue)
    {
        return GetClampableValue(currentValue - takeValue);
    }

    private int GetClampableValue(int value)
    {
        return Mathf.Clamp(value, _minValue, _maxValue);
    }
}
