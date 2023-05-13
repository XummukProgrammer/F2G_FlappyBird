using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    public Context LocalContext { get; private set; }

    public virtual void Init(Context context) 
    {
        LocalContext = context;
    }

    public virtual void Deinit() { }
    public abstract bool IsResult();
}
