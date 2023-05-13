using UnityEngine;

public static class SDKBuilder
{
    public static ISDK CreateSDK()
    {
        if (UnityEngine.Application.platform == RuntimePlatform.WebGLPlayer)
        {
            return new YaGamesSDK();
        }
        else if (UnityEngine.Application.platform == RuntimePlatform.WindowsPlayer || UnityEngine.Application.platform == RuntimePlatform.WindowsEditor)
        {
            return new WinSDK();
        }

        return null;
    }
}
