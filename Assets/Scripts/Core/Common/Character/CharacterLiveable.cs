using UnityEngine;

public class CharacterLiveable : MonoBehaviour
{
    public event System.Action Died;

    [SerializeField] private Resource _healthResource;
    [SerializeField] private Character _character;
    [SerializeField] private bool _isDestroyOnDeath = true;

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
            Died?.Invoke();

            if (_isDestroyOnDeath)
            {
                Destroy(_character.gameObject);
            }
        }
    }
}
