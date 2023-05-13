using UnityEngine;

public class SpawnConsistentlyChainPolicy : SpawnChainPolicy
{
    [SerializeField] private string[] _spawnIDs;

    private int _index = -1;

    public override int GetIndex(Spawn[] spawns)
    {
        ++_index;

        if (_index >= spawns.Length)
        {
            _index = 0;
        }

        return GetSpawnIndexByID(spawns, _spawnIDs[_index]);
    }

    private int GetSpawnIndexByID(Spawn[] spawns, string id)
    {
        bool isFinded = false;
        int resultID = 0;
        foreach (var spawn in spawns)
        {
            if (spawn.ID == id)
            {
                isFinded = true;
                break;
            }
            else
            {
                ++resultID;
            }
        }

        if (isFinded)
        {
            return resultID;
        }
        return -1;
    }
}
