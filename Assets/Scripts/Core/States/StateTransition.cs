using UnityEngine;

public class StateTransition : MonoBehaviour
{
    [SerializeField] private string _toStateID;

    public string ToStateID => _toStateID;
    public bool Realized => IsRealize();

    public void Init(Context localContext)
    {
        var condition = GetComponent<Condition>();
        if (condition)
        {
            condition.Init(localContext);
        }
    }

    public void Deinit()
    {
        var condition = GetComponent<Condition>();
        if (condition)
        {
            condition.Deinit();
        }
    }

    private bool IsRealize()
    {
        var condition = GetComponent<Condition>();
        if (condition)
        {
            return condition.IsResult();
        }
        return false;
    }
}
