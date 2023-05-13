using UnityEngine;

public class ResourceChangePolicy : MonoBehaviour
{
    public virtual int AddValue(int currentValue, int addValue) { return currentValue + addValue; }
    public virtual int TakeValue(int currentValue, int takeValue) { return currentValue - takeValue; }
}
