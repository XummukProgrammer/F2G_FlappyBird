using UnityEngine;

public class BaseResourceChangedBehaviour : MonoBehaviour
{
    [SerializeField] private string _resourceID;
    [SerializeField] private int _value = 1;
    [SerializeField] private ResourceUsePolicy _usePolicy;
    [SerializeField] private bool _isDestroyOnUse = true;

    // TODO: Продумать таймер, когда можно воспользоваться изменением ресурсов ещё раз.
    private bool _isUsed = false;

    private void Update()
    {
        if (!_isUsed && _usePolicy && _usePolicy.CanUse())
        {
            OperationWithResource(_usePolicy.Resource, _value);

            if (_isDestroyOnUse)
            {
                Destroy(gameObject);
            }

            _isUsed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
        {
            if (character.Resources)
            {
                var resource = character.Resources.GetResource(_resourceID);
                if (resource != null)
                {
                    if (_usePolicy)
                    {
                        _usePolicy.Init(gameObject.transform, character, resource);
                        _usePolicy.OnEnter();
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
        {
            if (_usePolicy && _usePolicy.Character == character)
            {
                _usePolicy.Init(null, null, null);
                _usePolicy.OnExit();
            }
        }
    }

    protected virtual void OperationWithResource(Resource resource, int value) { }
}
