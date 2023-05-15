using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawn[] _spawns;
    [SerializeField] private Transform _container;
    [SerializeField] private SpawnChainPolicy _chainPolicy;
    [SerializeField] private SpawnFrequencyPolicy _frequencyPolicy;

    private bool _isEnabled = false;

    public void SetIsEnabled(bool isEnabled)
    {
        _isEnabled = isEnabled;

        if (!_isEnabled)
        {
            if (_chainPolicy)
            {
                _chainPolicy.ResetData();
            }

            if (_frequencyPolicy)
            {
                _frequencyPolicy.ResetData();
            }
        }
    }

    public void Spawn(Spawn spawn)
    {
        if (_isEnabled && spawn != null)
        {
            spawn.Create(_container);
        }
    }

    public void Spawn(string id)
    {
        if (!_isEnabled)
        {
            return;
        }

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
        if (_isEnabled && _chainPolicy)
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
        if (!_isEnabled)
        {
            return;
        }

        foreach (var spawn in _spawns)
        {
            Spawn(spawn);
        }
    }

    private void Update()
    {
        if (!_isEnabled)
        {
            return;
        }

        bool canSpawn = false;
        if (_frequencyPolicy)
        {
            _frequencyPolicy.OnUpdate();
            canSpawn = _frequencyPolicy.CanSpawn();
        }

        if (canSpawn)
        {
            SpawnByChainPolicy();
        }
    }

    public void Reload()
    {
        for (int i = 0; i < _container.childCount; ++i)
        {
            Destroy(_container.GetChild(i).gameObject);
        }

        SetIsEnabled(false);
        SetIsEnabled(true);
    }
}
