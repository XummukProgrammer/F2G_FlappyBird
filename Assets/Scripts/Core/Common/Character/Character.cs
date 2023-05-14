using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private CharacterLiveable _liveable;

    public Resources Resources => _resources;
    public CharacterLiveable Liveable => _liveable;
}
