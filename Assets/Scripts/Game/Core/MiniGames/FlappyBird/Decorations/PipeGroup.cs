using UnityEngine;

public class PipeGroup : MonoBehaviour
{
    [SerializeField] private float _leftMoveSpeed = 1;
    [SerializeField] private float _leftDistanceToDestroy = 10;

    private float _startXPosition;

    private void Start()
    {
        _startXPosition = transform.position.x;
    }

    private void Update()
    {
        var position = transform.position;
        position.x -= _leftMoveSpeed * Time.deltaTime;
        transform.position = position;

        if (Mathf.Abs(transform.position.x - _startXPosition) >= _leftDistanceToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
