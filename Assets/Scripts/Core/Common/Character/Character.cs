using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Resources _resources;

    public Resources Resources => _resources;
}
