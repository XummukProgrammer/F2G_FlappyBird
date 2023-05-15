using UnityEngine;

public class FlappyBirdResultWindowBehaviour : WindowBehaviour
{
    public DefaultDelegate Resumed;
    public DefaultDelegate Mained;

    [SerializeField] private UpdatableText _moneyText;
    
    public void SetMoney(int money)
    {
        _moneyText.SetText(money.ToString());
    }

    public void OnResume()
    {
        Resumed?.Invoke();
        OnClose();
    }

    public void OnMain()
    {
        Mained?.Invoke();
    }
}
