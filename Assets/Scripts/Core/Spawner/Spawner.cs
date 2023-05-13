using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawn[] _spawns;
    [SerializeField] private Transform _container;
    [SerializeField] private SpawnChainPolicy _chainPolicy;
    [SerializeField] private SpawnFrequencyPolicy _frequencyPolicy;

    public void Spawn(Spawn spawn)
    {
        if (spawn != null)
        {
            spawn.Create(_container);
        }
    }

    public void Spawn(string id)
    {
        foreach (var spawn in _spawns)
        {
            if (spawn.ID == id)
            {
                Spawn(spawn);
            }    
        }
    }

    public void SpawnByChainPolicy()
    {
        if (_chainPolicy)
        {
            int index = _chainPolicy.GetIndex(_spawns);
            if (index >= 0 && index < _spawns.Length)
            {
                Spawn(_spawns[index]);
            }
        }
    }

    public void SpawnAll()
    {
        foreach (var spawn in _spawns)
        {
            Spawn(spawn);
        }
    }

    private void Update()
    {
        if (_frequencyPolicy && _frequencyPolicy.CanSpawn())
        {
            SpawnByChainPolicy();
        }
    }
}
