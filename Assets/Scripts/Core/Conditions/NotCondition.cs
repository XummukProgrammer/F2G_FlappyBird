using UnityEngine;

public class NotCondition : Condition
{
    [SerializeField] private Condition _condition;

    public override bool IsResult()
    {
        if (_condition)
        {
            return !_condition.IsResult();
        }
        return true;
    }
}
