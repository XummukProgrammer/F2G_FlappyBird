using UnityEngine;

public class SpawnTimeFrequencyPolicy : SpawnFrequencyPolicy
{
    [SerializeField] private float _spawnTime = 1;

    private bool _canSpawn;
    private float _time = 0;

    public override bool CanSpawn() 
    { 
        if (_canSpawn)
        {
            _canSpawn = false;
            return true;
        }
        return false; 
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _spawnTime)
        {
            _canSpawn = true;
            _time = 0;
        }
    }
}
