public interface IArchive
{
    public void Save();
    public void Load();

    public bool HasKey(string key);

    public void SetInt(string key, int value);
    public int GetInt(string key);

    public void SetString(string key, string value);
    public string GetString(string key);

    public void ResetData();
}
