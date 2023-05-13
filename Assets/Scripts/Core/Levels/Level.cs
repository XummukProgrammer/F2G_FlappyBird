using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private string _miniGameName;
    [SerializeField] private MiniGame _miniGamePrefab;
    [SerializeField] private Camera _camera;

    public Camera Camera => _camera;

    private void Start()
    {
        Application.Instance.Managers.GetManager<MiniGames>().AddElement(_miniGamePrefab);
    }

    public void Play()
    {
        var action = new MiniGamePlayAction();
        action.ID = $"PlayMiniGame_{_miniGameName}_Action";
        action.MiniGameName = _miniGameName;
        Application.Instance.ActionsQueue.AddAction(action);
    }
}
