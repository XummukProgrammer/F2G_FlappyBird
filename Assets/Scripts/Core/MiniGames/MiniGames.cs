using UnityEngine;

public class MiniGames : Manager<MiniGame>
{
    private MiniGame _currentMiniGame;

    public MiniGame CurrentMiniGame => _currentMiniGame;

    public override void OnInit() 
    {
        if (_currentMiniGame)
        {
            _currentMiniGame.OnInit();
        }
    }

    public override void OnDeinit() 
    {
        if (_currentMiniGame)
        {
            _currentMiniGame.OnDeinit();
        }
    }
    
    public override void OnUpdate() 
    { 
        if (_currentMiniGame)
        {
            _currentMiniGame.OnUpdate();
        }
    }

    public override void OnFixedUpdate() 
    {
        if (_currentMiniGame)
        {
            _currentMiniGame.OnFixedUpdate();
        }
    }

    public override bool IsInitElement() { return false; }

    public void PlayMiniGame(string name)
    {
        var prefab = GetElement(name);

        if (prefab)
        {
            _currentMiniGame = GameObject.Instantiate(prefab, Application.Instance.Level.transform);
            _currentMiniGame.Camera = Application.Instance.Level.Camera;
            _currentMiniGame.StartMiniGame();
        }
    }
}
