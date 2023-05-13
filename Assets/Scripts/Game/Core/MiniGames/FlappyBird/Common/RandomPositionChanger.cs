using UnityEngine;

public class RandomPositionChanger : MonoBehaviour
{
    [SerializeField] private Vector2 _xOffset;
    [SerializeField] private Vector2 _yOffset;

    private void Start()
    {
        var position = transform.position;
        position.x += Random.Range(_xOffset.x, _xOffset.y);
        position.y += Random.Range(_yOffset.x, _yOffset.y);
        transform.position = position;
    }
}
