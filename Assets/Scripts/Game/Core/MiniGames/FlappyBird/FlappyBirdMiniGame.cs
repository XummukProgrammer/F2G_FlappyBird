using UnityEngine;

public class FlappyBirdMiniGame : MiniGame
{
    [SerializeField] private Bird _bird;

    public Bird Bird => _bird;
}
