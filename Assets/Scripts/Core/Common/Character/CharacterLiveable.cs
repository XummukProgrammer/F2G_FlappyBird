using UnityEngine;

public class CharacterLiveable : MonoBehaviour
{
    [SerializeField] private Resource _healthResource;
    [SerializeField] private Character _character;

    private void Awake()
    {
        if (_healthResource)
        {
            _healthResource.ValueChanged += OnHealthChanged;
        }
    }

    private void OnDestroy()
    {
        if (_healthResource)
        {
            _healthResource.ValueChanged -= OnHealthChanged;
        }
    }

    private void OnHealthChanged(Resource resource)
    {
        if (resource.Value <= 0)
        {
            Destroy(_character.gameObject);
        }
    }
}
