using UnityEngine;

public class SpawnTimeFrequencyPolicy : SpawnFrequencyPolicy
{
    [SerializeField] private float _spawnTime = 1;

    private bool _canSpawn;
    private float _time = 0;

    public override void ResetData()
    {
        _canSpawn = false;
        _time = 0;
    }

    public override bool CanSpawn() 
    { 
        if (_canSpawn)
        {
            _canSpawn = false;
            return true;
        }
        return false; 
    }

    public override void OnUpdate()
    {
        _time += Time.deltaTime;
        if (_time >= _spawnTime)
        {
            _canSpawn = true;
            _time = 0;
        }
    }
}
