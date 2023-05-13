using UnityEngine;

public class ResourceUseDistancePolicy : ResourceUsePolicy
{
    [SerializeField] private float _distance = 1;

    public override bool CanUse()
    {
        if (base.CanUse())
        {
            return Vector2.Distance(ChangeableTransform.position, Character.transform.position) < _distance;
        }
        return false;
    }
}
