using UnityEngine;

public class ManagerableElement : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name => _name;

    public virtual void OnInit() { }
    public virtual void OnDeinit() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
}
