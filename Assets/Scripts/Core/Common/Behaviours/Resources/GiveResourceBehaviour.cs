public class GiveResourceBehaviour : BaseResourceChangedBehaviour
{
    protected override void OperationWithResource(Resource resource, int value)
    {
        resource.AddValue(value);
    }
}
