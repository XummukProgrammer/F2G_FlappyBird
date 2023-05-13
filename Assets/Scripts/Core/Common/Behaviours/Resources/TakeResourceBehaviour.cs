public class TakeResourceBehaviour : BaseResourceChangedBehaviour
{
    protected override void OperationWithResource(Resource resource, int value)
    {
        resource.TakeValue(value);
    }
}
