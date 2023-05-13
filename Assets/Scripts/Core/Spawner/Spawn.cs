using UnityEngine;

[System.Serializable]
public class Spawn
{
    [SerializeField] private string _id;
    [SerializeField] private Transform _prefab;
    [SerializeField] private Vector2 _position;

    public string ID => _id;

    public void Create(Transform container)
    {
        var obj = GameObject.Instantiate(_prefab, container);
        obj.transform.position = _position;
    }
}
