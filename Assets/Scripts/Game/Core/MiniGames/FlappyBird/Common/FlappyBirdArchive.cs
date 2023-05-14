using UnityEngine;

public class FlappyBirdArchive : MonoBehaviour
{
    public int Money { private set; get; }

    private void Start()
    {
        LoadMoney();

        var bird = FlappyBirdMiniGameUtils.GetBird();
        if (bird)
        {
            bird.SetMoney(Money);
        }

        var moneyResource = GetMoneyResource();
        if (moneyResource)
        {
            moneyResource.ValueChanged += OnMoneyValueChanged;
        }
    }

    private void OnDestroy()
    {
        var moneyResource = GetMoneyResource();
        if (moneyResource)
        {
            moneyResource.ValueChanged -= OnMoneyValueChanged;
        }
    }

    private Resource GetMoneyResource()
    {
        var bird = FlappyBirdMiniGameUtils.GetBird();
        if (bird)
        {
            return bird.MoneyResource;
        }
        return null;
    }

    private void OnMoneyValueChanged(Resource resource)
    {
        SetMoney(resource.Value);
    }

    private void LoadMoney()
    {
        if (Application.Instance.Archive.HasKey("money"))
        {
            Money = Application.Instance.Archive.GetInt("money");
        }
    }

    private void SetMoney(int money)
    {
        Money = money;
        Application.Instance.Archive.SetInt("money", Money);
        Application.Instance.Archive.Save();
    }
}
