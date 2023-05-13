using UnityEngine;

public class SpawnFrequencyPolicy : MonoBehaviour
{
    public virtual bool CanSpawn() { return false; }
}
