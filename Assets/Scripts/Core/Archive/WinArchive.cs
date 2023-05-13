using UnityEngine;

public class WinArchive : IArchive
{
    public int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public void Load()
    {
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
}
