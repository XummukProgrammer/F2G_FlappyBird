using UnityEngine;

public class SpawnChainPolicy : MonoBehaviour
{
    public virtual int GetIndex(Spawn[] spawns) { return 0; }
}
