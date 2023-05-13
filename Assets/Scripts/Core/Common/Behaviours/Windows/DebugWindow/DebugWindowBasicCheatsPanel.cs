using UnityEngine;

public class DebugWindowBasicCheatsPanel : MonoBehaviour
{
    public delegate void DefaultDelegate();

    public DefaultDelegate AppClosed;

    public void OnCloseApp()
    {
        AppClosed?.Invoke();
    }
}
