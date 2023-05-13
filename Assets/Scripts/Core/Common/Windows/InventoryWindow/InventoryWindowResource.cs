using UnityEngine;

public class InventoryWindowResource : MonoBehaviour
{
    [SerializeField] private InventoryWindowResourceBehaviour _behaviour;

    private Resource _resource;

    public void Init(Resource resource)
    {
        _resource = resource;

        _behaviour.SetName(_resource.Name);
        _behaviour.SetValue(_resource.Value);

        _resource.ValueChanged += OnResourceValueChanged;
    }

    public void Deinit()
    {
        _resource.ValueChanged -= OnResourceValueChanged;
    }

    private void OnResourceValueChanged(Resource resource)
    {
        _behaviour.SetValue(_resource.Value);
    }
}
