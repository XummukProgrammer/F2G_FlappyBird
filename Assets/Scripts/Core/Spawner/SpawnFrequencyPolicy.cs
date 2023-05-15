using UnityEngine;

public class SpawnFrequencyPolicy : MonoBehaviour
{
    public virtual void ResetData() { }
    public virtual void OnUpdate() { }
    public virtual bool CanSpawn() { return false; }
}
