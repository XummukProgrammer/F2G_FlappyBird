using UnityEngine;

public class FlappyBirdMiniGame : MiniGame
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Spawner _spawner;

    public Bird Bird => _bird;
    public Spawner Spawner => _spawner;
}
