using UnityEngine;

public class BirdJumpHUDBehaviour : HUDBehaviour
{
    public event System.Action TappedToArea;

    public void OnTappedToArea()
    {
        TappedToArea?.Invoke();
    }
}
