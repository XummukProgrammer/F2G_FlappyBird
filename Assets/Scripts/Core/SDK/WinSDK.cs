public class WinSDK : ISDK
{
    public IArchive GetArchive()
    {
        return new WinArchive();
    }

    SDKType ISDK.GetType()
    {
        return SDKType.Win;
    }
}
