using UnityEngine;

public class ResourceUsePolicy : MonoBehaviour
{
    public Transform ChangeableTransform { get; private set; }
    public Character Character { get; private set; }
    public Resource Resource { get; private set; }

    public void Init(Transform changeableTransform, Character character, Resource resource)
    {
        ChangeableTransform = changeableTransform;
        Character = character;
        Resource = resource;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual bool CanUse() { return ChangeableTransform && Character && Resource; }
}
