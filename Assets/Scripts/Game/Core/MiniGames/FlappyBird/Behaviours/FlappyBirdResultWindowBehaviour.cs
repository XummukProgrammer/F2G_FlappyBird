using UnityEngine;

public class FlappyBirdResultWindowBehaviour : WindowBehaviour
{
    public DefaultDelegate Resumed;
    public DefaultDelegate Mained;

    [SerializeField] private TMPro.TMP_Text _moneyText;
    
    public void SetMoney(int money)
    {
        _moneyText.text = $"�� ������� {money} �����!";
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
