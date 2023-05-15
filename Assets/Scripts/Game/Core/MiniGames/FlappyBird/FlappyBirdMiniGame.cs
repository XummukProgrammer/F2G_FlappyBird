using UnityEngine;

public class FlappyBirdMiniGame : MiniGame
{
    [SerializeField] private Bird _birdPrefab;
    [SerializeField] private Transform _birdContainer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private FlappyBirdResultWindow _resultWindow;
    [SerializeField] private FlappyBirdArchive _archive;
    [SerializeField] private FlappyBirdInfo _info;
    [SerializeField] private Transform _pipes;

    private Bird _bird;

    public Bird Bird => _bird;
    public Spawner Spawner => _spawner;
    public FlappyBirdResultWindow ResultWindow => _resultWindow;
    public FlappyBirdArchive Archive => _archive;
    public FlappyBirdInfo Info => _info;

    public void CreateBird()
    {
        _bird = Instantiate(_birdPrefab, _birdContainer);
    }

    public void RemoveBird()
    {
        Destroy(_bird.gameObject);
        _bird = null;
    }
}
