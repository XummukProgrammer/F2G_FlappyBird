public class Location
{
    public event System.Action<LocationID> IDChanged;

    public LocationID ID { get; private set; }

    public void SetID(LocationID ID)
    {
        this.ID = ID;
        IDChanged?.Invoke(this.ID);
    }
}
