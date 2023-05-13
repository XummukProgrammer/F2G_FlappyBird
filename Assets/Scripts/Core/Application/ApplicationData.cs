using UnityEngine;

[CreateAssetMenu(fileName = "ApplicationData", menuName = "Core/Data/Application")]
public class ApplicationData : ScriptableObject
{
    [SerializeField] private string _name = "Roguelike";
    [SerializeField] private string _version = "1.0.0.0 alpha";

    public string Name => _name;
    public string Version => _version;
}
