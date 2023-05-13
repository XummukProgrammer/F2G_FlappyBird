using UnityEngine.EventSystems;

public class OpenWindowHUDBehaviour : HUDBehaviour, IPointerClickHandler
{
    public delegate void ClickedDelegate();

    public ClickedDelegate Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked();
    }

    public void OnClicked()
    {
        Clicked?.Invoke();
    }
}
