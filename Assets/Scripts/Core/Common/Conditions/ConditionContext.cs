using UnityEngine;

public class ConditionContext : Condition
{
    [SerializeField] private string _ID;
    [SerializeField] private string _value;
    [SerializeField] private bool _isGlobal = true;

    public override bool IsResult()
    {
        Context context = null;

        if (_isGlobal)
        {
            context = Application.Instance.GlobalContext;
        }
        else
        {
            context = LocalContext;
        }

        if (context != null)
        {
            return context.GetVariable(_ID) == _value;
        }
        return false;
    }
}
