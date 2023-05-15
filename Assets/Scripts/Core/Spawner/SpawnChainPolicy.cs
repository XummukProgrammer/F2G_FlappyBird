using UnityEngine;

public class SpawnChainPolicy : MonoBehaviour
{
    public virtual void ResetData() { }
    public virtual int GetIndex(Spawn[] spawns) { return 0; }
}
