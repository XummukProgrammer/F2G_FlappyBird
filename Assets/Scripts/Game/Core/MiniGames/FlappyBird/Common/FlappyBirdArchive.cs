using UnityEngine;

public class FlappyBirdArchive : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private int _money = 0;

    private void Start()
    {
        LoadMoney();
        _bird.SetMoney(_money);

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
        if (_bird)
        {
            return _bird.MoneyResource;
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
            _money = Application.Instance.Archive.GetInt("money");
        }
    }

    private void SetMoney(int money)
    {
        _money = money;
        Application.Instance.Archive.SetInt("money", _money);
        Application.Instance.Archive.Save();
    }
}
