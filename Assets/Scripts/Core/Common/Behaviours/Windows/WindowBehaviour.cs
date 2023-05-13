using UnityEngine;

public class WindowBehaviour : MonoBehaviour
{
    public delegate void DefaultDelegate();

    public DefaultDelegate Closed;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClose()
    {
        Closed?.Invoke();
    }
}
