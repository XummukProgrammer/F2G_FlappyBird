using UnityEngine;

public class SpawnRandomChainPolicy : SpawnChainPolicy
{
    public override int GetIndex(Spawn[] spawns)
    {
        return Random.Range(0, spawns.Length);
    }
}
