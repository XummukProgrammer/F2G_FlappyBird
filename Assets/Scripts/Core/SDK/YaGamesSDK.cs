public class YaGamesSDK : ISDK
{
    public IArchive GetArchive()
    {
        return new YaGamesArchive();
    }

    SDKType ISDK.GetType()
    {
        return SDKType.YaGames;
    }
}
