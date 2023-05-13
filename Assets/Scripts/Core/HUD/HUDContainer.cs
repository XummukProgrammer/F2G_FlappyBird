using UnityEngine;

[System.Serializable]
public class HUDContainerElement
{
    [SerializeField] private HUDLocation _location;
    [SerializeField] private Transform _container;

    public HUDLocation Location => _location;
    public Transform Container => _container;
}

public class HUDContainer : MonoBehaviour
{
    [SerializeField] private HUDContainerElement[] _elements;

    public Transform GetContainer(HUDLocation location)
    {
        foreach (var element in _elements)
        {
            if (element.Location == location)
            {
                return element.Container;
            }
        }
        return null;
    }
}
