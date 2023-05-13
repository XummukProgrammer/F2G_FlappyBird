using System.Collections.Generic;

public class BaseManager
{
    public virtual void OnInit() { }
    public virtual void OnDeinit() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
}

public class Manager<T> : BaseManager where T : ManagerableElement
{
    protected List<T> _elements = new();

    public override void OnInit() 
    {
        base.OnInit();

        foreach (var element in _elements)
        {
            element.OnInit();
        }
    }

    public override void OnDeinit() 
    { 
        base.OnDeinit();

        foreach (var element in _elements)
        {
            element.OnDeinit();
        }
    }

    public override void OnUpdate() 
    {
        base.OnUpdate();

        foreach (var element in _elements)
        {
            element.OnUpdate();
        }
    }

    public override void OnFixedUpdate() 
    {
        base.OnFixedUpdate();

        foreach (var element in _elements)
        {
            element.OnFixedUpdate();
        }
    }

    public void AddElement(T element)
    {
        _elements.Add(element);

        if (IsInitElement())
        {
            element.OnInit();
        }
    }

    public T GetElement(string name)
    {
        foreach (var element in _elements)
        {
            if (element.Name == name)
            {
                return element;
            }
        }

        return null;
    }

    public virtual bool IsInitElement() { return true; }
}
