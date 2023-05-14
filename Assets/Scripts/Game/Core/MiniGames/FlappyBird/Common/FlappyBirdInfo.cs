using UnityEngine;

public class FlappyBirdInfo : MonoBehaviour
{
    public int AddedMoneyOnLevel { get; private set; } = 0;

    public void ResetLevelData()
    {
        AddedMoneyOnLevel = 0;
    }

    private void Start()
    {
        var bird = FlappyBirdMiniGameUtils.GetBird();
        if (bird)
        {
            var moneyResource = bird.MoneyResource;
            if (moneyResource)
            {
                moneyResource.ValueAdded += OnBirdMoneyAdded;
            }
        }
    }

    private void OnDestroy()
    {
        var bird = FlappyBirdMiniGameUtils.GetBird();
        if (bird)
        {
            var moneyResource = bird.MoneyResource;
            if (moneyResource)
            {
                moneyResource.ValueAdded += OnBirdMoneyAdded;
            }
        }
    }

    private void OnBirdMoneyAdded(int prevValue, int currValue)
    {
        AddedMoneyOnLevel += currValue - prevValue;
    }
}
